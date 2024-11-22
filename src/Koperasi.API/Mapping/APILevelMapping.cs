using AutoMapper;
using apiModel = Koperasi.API.Models;
using applicationModel = Koperasi.Application.Models;

namespace Koperasi.API.Mapping
{
    public class APILevelMapping : Profile
    {
        public APILevelMapping()
        {
            CreateMap<applicationModel.Response.UserLoginResponse, apiModel.Response.LoginUserResponse>();
            CreateMap<applicationModel.Response.UserRegistrationResponse, apiModel.Response.RegisterUserResponse>();
        }
    }
}
