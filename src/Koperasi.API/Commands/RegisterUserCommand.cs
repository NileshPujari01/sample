using Koperasi.API.Models.Request;
using Koperasi.API.Models.Response;
using MediatR;

namespace Koperasi.API.Commands
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public RegisterUserRequest? RegisterUser { get; set; }

    }
}
