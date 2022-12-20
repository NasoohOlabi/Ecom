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
            CreateMap<Product, ProductDetailsViewModel>().ReverseMap();
            CreateMap<Product, ProductEditViewModel>().ReverseMap();
            CreateMap<ProductEditViewModel, ProductDetailsViewModel>().ReverseMap();

            CreateMap<Product, EditProductSpecificationsViewModel>()
                .ForMember(dest => dest.CategoryAttributes,
                opt => opt.Ignore())
                .ForMember(dest => dest.AllAttributes,
                opt => opt.Ignore())
                .ForMember(dest => dest.ProductSpecifications,
                opt => opt.MapFrom(src => src.Specifications))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ReverseMap();

        }
    }
}