using AutoMapper;
using DB.Models;
using Ecom.Models;

namespace Ecom.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEditViewModel, Category>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name}")
                );
            CreateMap<Category, CategoryEditViewModel>();

            CreateMap<Category, CategoryDetailsViewModel>();
            CreateMap<CategoryDetailsViewModel, Category>();
        }
    }
}

