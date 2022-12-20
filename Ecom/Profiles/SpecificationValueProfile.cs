using AutoMapper;
using DB.Models;
using Ecom.Models;

namespace Ecom.Profiles
{
    public class SpecificationValueProfile : Profile
    {
        public SpecificationValueProfile()
        {
            CreateMap<SpecificationValue, SpecificationValueDetailsViewModel>().ReverseMap();
            CreateMap<SpecificationValue, SpecificationValueEditViewModel>().ReverseMap();
            CreateMap<SpecificationValueEditViewModel, SpecificationValueDetailsViewModel>().ReverseMap();
        }
    }
}