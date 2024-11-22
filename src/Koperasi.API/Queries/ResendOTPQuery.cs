using Koperasi.API.Models.Request;
using Koperasi.API.Models.Response;
using MediatR;

namespace Koperasi.API.Queries
{
    public class ResendOTPQuery : IRequest<ResendOTPResponse>
    {
        public ResendOTPRequest ResendOTP { get; set; }
    }
}
