using Koperasi.Application.Models.Request;
using Koperasi.Application.Models.Response;

namespace Koperasi.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserRegistrationResponse> RegisterUser(UserRegistrationRequest registerRequest);
        Task<UserLoginResponse> UserLogin(UserLoginRequest userLoginRequest);
    }
}
