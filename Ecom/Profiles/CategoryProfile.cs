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

            CreateMap<CategoryHasAttribute, SelectAttributeViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AttributeId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId));

            CreateMap<CategoryHasAttribute, SelectAttributeViewModel>().ReverseMap();


            CreateMap<Attribute, CreateAttributeViewModel>();
            CreateMap<Attribute, CreateAttributeViewModel>().ReverseMap();

            //CreateMap<Attribute, CreateAttributeViewModel>();
            //CreateMap<Attribute, CreateAttributeViewModel>().ReverseMap();

            CreateMap<Category, EditCategoryAttributesViewModel>()
                .ForMember(dest => dest.CategoryAttributes,
                opt => opt.MapFrom(src => from cha in src.CategoryHasAttributes
                                          select new SelectAttributeViewModel { Id = cha.AttributeId, Name = cha.Attribute.Name }
                                          ))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<EditCategoryAttributesViewModel, Category>()
                .ForMember(dest => dest.CategoryHasAttributes,
                opt => opt.MapFrom(src => from cha in src.CategoryAttributes
                                          select new CategoryHasAttribute { AttributeId = cha.Id, CategoryId = src.Id}
                                          ))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}