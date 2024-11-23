using AutoMapper;
using apiModel = Koperasi.API.Models;
using applicationModel = Koperasi.Application.Models;

namespace Koperasi.API.Mapping
{
    /// <summary>
    /// Automapper profile for request and response between API and Application layer
    /// </summary>
    public class APILevelMapping : Profile
    {
        public APILevelMapping()
        {
            CreateMap<apiModel.Request.LoginUserRequest, applicationModel.Request.UserLoginRequest>();
            CreateMap<apiModel.Request.RegisterUserRequest, applicationModel.Request.UserRegistrationRequest>();

            CreateMap<applicationModel.Response.UserLoginResponse, apiModel.Response.LoginUserResponse>();
            CreateMap<applicationModel.Response.UserRegistrationResponse, apiModel.Response.RegisterUserResponse>();
        }
    }
}
