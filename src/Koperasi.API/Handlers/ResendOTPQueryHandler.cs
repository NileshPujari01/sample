using AutoMapper;
using Koperasi.API.Models.Response;
using Koperasi.API.Queries;
using Koperasi.Application.Interfaces;
using Koperasi.Infrastructure.Abstractions;
using MediatR;

namespace Koperasi.API.Handlers
{
    public class ResendOTPQueryHandler : IRequestHandler<ResendOTPQuery, ResendOTPResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IOTPService _otpService;

        public ResendOTPQueryHandler(IUserService userService, IMapper mapper, IOTPService otpService)
        {
            _userService = userService;
            _mapper = mapper;
            _otpService = otpService;
        }

        public async Task<ResendOTPResponse> Handle(ResendOTPQuery request, CancellationToken cancellationToken)
        {
            ResendOTPResponse otpToVerify = new ResendOTPResponse();

            if (request == null)
                return otpToVerify;

            if (!string.IsNullOrEmpty(request.ResendOTP.CustomerMobileNo))
                otpToVerify.ResendOTP = await _otpService.SendOTPOverMobile(request.ResendOTP.CustomerMobileNo);
            else if (!string.IsNullOrEmpty(request.ResendOTP.CustomerEmailId))
                otpToVerify.ResendOTP = await _otpService.SendOTPOverEmail(request.ResendOTP.CustomerEmailId);

            return otpToVerify;
        }
    }
}
