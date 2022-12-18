using AutoMapper;
using DB.Models;
using Ecom.Models;
using System;
using Attribute = DB.Models.Attribute;

namespace Ecom.Profiles
{
    public class ProdcutProfile : Profile
    {
        public ProdcutProfile()
        {
            CreateMap<Product, ProductDetailsViewModel>();
            CreateMap<ProductEditViewModel, ProductDetailsViewModel>().ReverseMap();

            CreateMap<Product, ProductEditViewModel>().ReverseMap();

            CreateMap<Product, EditProductSpecificationsViewModel>()
                .ForMember(dest => dest.CategoryAttributes,
                opt => opt.Ignore())
                .ForMember(dest => dest.AllAttributes,
                opt => opt.Ignore())
                .ForMember(dest => dest.ProductSpecifications,
                opt => opt.MapFrom(src => src.Specifications))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<DB.Repos.EditProductSpecificationsViewModel, EditProductSpecificationsViewModel>();
            CreateMap<DB.Repos.EditProductSpecificationsViewModel, EditProductSpecificationsViewModel>().ReverseMap();

            CreateMap<Attribute, EditAttributeViewModel>();
            CreateMap<Attribute, EditAttributeViewModel>().ReverseMap();

            CreateMap<SpecificationValue, SelectValueViewModel>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Specification, SelectSpecificationViewModel>()
                .ForMember(dest => dest.Attribute, opt => opt.MapFrom(src => src.Attribute))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.SpecificationValue));
            CreateMap<Specification, SelectSpecificationViewModel>().ReverseMap();



            CreateMap<DB.Repos.SelectAttributeViewModel, SelectAttributeViewModel>();
            CreateMap<DB.Repos.SelectAttributeViewModel, SelectAttributeViewModel>().ReverseMap();
            CreateMap<DB.Repos.SelectSpecificationViewModel, SelectSpecificationViewModel>();
            CreateMap<DB.Repos.SelectSpecificationViewModel, SelectSpecificationViewModel>().ReverseMap();
            CreateMap<DB.Repos.SelectAttributeViewModel, SelectAttributeViewModel>();
            CreateMap<DB.Repos.SelectAttributeViewModel, SelectAttributeViewModel>().ReverseMap();
            CreateMap<DB.Repos.SelectValueViewModel, SelectValueViewModel>();
            CreateMap<DB.Repos.SelectValueViewModel, SelectValueViewModel>().ReverseMap();
            CreateMap<DB.Repos.EditAttributeViewModel, EditAttributeViewModel>();
            CreateMap<DB.Repos.EditAttributeViewModel, EditAttributeViewModel>().ReverseMap();
            CreateMap<DB.Repos.SelectSpecificationViewModel, SelectSpecificationViewModel>();
            CreateMap<DB.Repos.SelectSpecificationViewModel, SelectSpecificationViewModel>().ReverseMap();

        }
    }
}