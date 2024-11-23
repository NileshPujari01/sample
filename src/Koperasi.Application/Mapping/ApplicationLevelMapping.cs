using AutoMapper;
using applicationModel = Koperasi.Application.Models;
using entityModel = Koperasi.Domain.Entities;

namespace Koperasi.Application.Mapping
{
    /// <summary>
    /// Automapper profile for request and response between application and domain(entity) layer
    /// </summary>
    public class ApplicationLevelMapping: Profile
    {
        public ApplicationLevelMapping()
        {
            CreateMap<applicationModel.Request.UserLoginRequest, entityModel.UserEntity>();
            CreateMap<entityModel.UserEntity, applicationModel.Response.UserLoginResponse>();

            CreateMap<applicationModel.Request.UserRegistrationRequest, entityModel.UserEntity>();
            CreateMap<entityModel.UserEntity, applicationModel.Response.UserRegistrationResponse>()
                .ForMember(dest => dest.CustomerUserId, opt => opt.MapFrom(dest => dest.UserId));
        }
    }
}
