using AutoMapper;
using Koperasi.API.Models.Response;
using Koperasi.API.Queries;
using Koperasi.Application.Interfaces;
using Koperasi.Application.Models.Request;
using Koperasi.Infrastructure.Abstractions;
using MediatR;

namespace Koperasi.API.Handlers
{
    /// <summary>
    /// Handler to manage user login
    /// </summary>
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IOTPService _otpService;

        public LoginUserQueryHandler(
            IUserService userService, 
            IMapper mapper,
            IOTPService otpService)
        {
            _userService = userService;
            _mapper = mapper;
            _otpService = otpService;
        }

        public async Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var loginRequest = _mapper.Map<UserLoginRequest>(request.LoginUserRequest);
            var dbResponse = await _userService.UserLogin(loginRequest);

            if (dbResponse != null)
            {
                Task<int> verifyMobile = Task.Run(async () => await _otpService.SendOTPOverMobile(dbResponse.CustomerMobileNo));
                Task<int> verifyEmail = Task.Run(async () => await _otpService.SendOTPOverEmail(dbResponse.CustomerEmailId));
                await Task.WhenAll(verifyMobile,verifyEmail);

                var response = _mapper.Map<LoginUserResponse>(dbResponse);
                response.MobileNoOTP = verifyMobile.Result;
                response.EmailIdOTP = verifyEmail.Result;

                return response;
            }

            return new LoginUserResponse();
        }
    }
}
