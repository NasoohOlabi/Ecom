using AutoMapper;
using DB.Models;
using Ecom.Models;

namespace Ecom.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDetailsViewModel>();
            CreateMap<Category, CategoryEditViewModel>().ReverseMap();
        }
    }
}