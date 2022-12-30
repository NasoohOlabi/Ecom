using AutoMapper;
using DB.Models;
using Ecom.Areas.Identity.Pages.Account;
using Ecom.Models;

namespace Ecom.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDetailsViewModel>().ReverseMap();
            CreateMap<User, UserEditViewModel>().ReverseMap();
            CreateMap<UserEditViewModel, UserDetailsViewModel>().ReverseMap();

            CreateMap<RegisterModel.InputModel, User>().ReverseMap();
        }
    }
}