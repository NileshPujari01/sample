using AutoMapper;
using applicationModel = Koperasi.Application.Models;
using entityModel = Koperasi.Domain.Entities;

namespace Koperasi.Application.Mapping
{
    public class ApplicationLevelMapping: Profile
    {
        public ApplicationLevelMapping()
        {
            CreateMap<applicationModel.Request.UserRegistrationRequest, entityModel.UserEntity>();

            CreateMap<entityModel.UserEntity, applicationModel.Response.UserRegistrationResponse>()
                .ForMember(dest => dest.CustomerUserId, opt => opt.MapFrom(dest => dest.UserId));
        }
    }
}
