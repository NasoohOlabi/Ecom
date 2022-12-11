using AutoMapper;
using DB.Models;
using Ecom.Models;

namespace Ecom.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDetailsViewModel>();
            CreateMap<Role, RoleEditViewModel>().ReverseMap();
            CreateMap<RoleEditViewModel, RoleDetailsViewModel>().ReverseMap();
        }
    }
}