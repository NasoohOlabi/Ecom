using AutoMapper;
using DB.Models;
using Ecom.Models;
using Attribute = DB.Models.Attribute;

namespace Ecom.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDetailsViewModel>();
            CreateMap<Category, CategoryEditViewModel>().ReverseMap();
            CreateMap<CategoryEditViewModel, CategoryDetailsViewModel>().ReverseMap();
            CreateMap<Attribute, SelectAttributeViewModel>();
            CreateMap<Attribute, SelectAttributeViewModel>().ReverseMap();

            CreateMap<CategoryHasAttribute, SelectAttributeViewModel>();
            CreateMap<CategoryHasAttribute, SelectAttributeViewModel>().ReverseMap();


            CreateMap<Attribute, CreateAttributeViewModel>();
            CreateMap<Attribute, CreateAttributeViewModel>().ReverseMap();

            //CreateMap<Attribute, CreateAttributeViewModel>();
            //CreateMap<Attribute, CreateAttributeViewModel>().ReverseMap();

        }
    }
}