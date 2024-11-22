using Koperasi.API.Models.Request;
using Koperasi.API.Models.Response;
using MediatR;

namespace Koperasi.API.Queries
{
    public class LoginUserQuery : IRequest<LoginUserResponse>
    {
        public LoginUserRequest LoginUserRequest { get; set; }
    }
}
