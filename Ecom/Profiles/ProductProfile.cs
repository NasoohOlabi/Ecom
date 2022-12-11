using AutoMapper;
using DB.Models;
using Ecom.Models;

namespace Ecom.Profiles
{
    public class ProdcutProfile : Profile
    {
        public ProdcutProfile()
        {
            CreateMap<Product, ProductDetailsViewModel>();
            CreateMap<Product, ProductEditViewModel>().ReverseMap();
            CreateMap<ProductEditViewModel, ProductDetailsViewModel>().ReverseMap();
        }
    }
}