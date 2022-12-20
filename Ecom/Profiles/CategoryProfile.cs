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
            CreateMap<Category, CategoryEditViewModel>().ReverseMap();
            CreateMap<Category, CategoryDetailsViewModel>().ReverseMap();
            CreateMap<CategoryEditViewModel, CategoryDetailsViewModel>().ReverseMap();
            
            CreateMap<CategoryHasAttribute, AttributeDetailsViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AttributeId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId)).ReverseMap();



            CreateMap<Category, EditCategoryAttributesViewModel>()
                .ForMember(dest => dest.CategoryAttributes,
                opt => opt.MapFrom(src => from cha in src.CategoryHasAttributes
                                          select new AttributeDetailsViewModel { Id = cha.AttributeId, Name = cha.Attribute!.Name }
                                          ))
                .ForMember(dest => dest.AllAttributes,
                opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ReverseMap();

        }
    }
}