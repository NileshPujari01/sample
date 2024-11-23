using AutoMapper;
using Koperasi.API.Commands;
using Koperasi.API.Models.Response;
using MediatR;
using Koperasi.Application.Interfaces;
using Koperasi.Application.Models.Request;
using Koperasi.Infrastructure.Abstractions;

namespace Koperasi.API.Handlers
{
    /// <summary>
    /// Handler to manage registration of user
    /// </summary>
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<RegisterUserCommandHandler> _logger;
        private readonly IOTPService _otpService;

        public RegisterUserCommandHandler(
                IUserService userService,
                IMapper mapper,
                ILogger<RegisterUserCommandHandler> logger,
                IOTPService otpService)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
            _otpService = otpService;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerRequest = _mapper.Map<UserRegistrationRequest>(request.RegisterUser);

            Task<int> verifyMobile = Task.Run(async () => await _otpService.SendOTPOverMobile(request.RegisterUser.CustomerMobileNo));
            Task<int> verifyEmail = Task.Run(async () => await _otpService.SendOTPOverEmail(request.RegisterUser.CustomerEmailId));
            await Task.WhenAll(verifyMobile, verifyEmail);

            if (verifyMobile.Result > 0 && verifyEmail.Result > 0)
            {
                var dbResponse = await _userService.RegisterUser(registerRequest);
                var response = _mapper.Map<RegisterUserResponse>(dbResponse);
                response.MobileNoOTP = verifyMobile.Result;
                response.EmailIdOTP = verifyEmail.Result;
                return response;
            }
            
            return new RegisterUserResponse();
        }
    }
}
