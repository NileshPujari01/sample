using Koperasi.API.Models.Request;
using Koperasi.API.Models.Response;
using MediatR;

namespace Koperasi.API.Queries
{
    /// <summary>
    /// Query for control user login
    /// </summary>
    public class LoginUserQuery : IRequest<LoginUserResponse>
    {
        public LoginUserRequest LoginUserRequest { get; set; }
    }
}
