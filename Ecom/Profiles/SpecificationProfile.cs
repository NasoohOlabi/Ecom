using AutoMapper;
using DB.Models;
using Ecom.Models;

namespace Ecom.Profiles
{
    public class SpecificationProfile : Profile
    {
        public SpecificationProfile()
        {
            CreateMap<Specification, SpecificationDetailsViewModel>().ReverseMap();
            CreateMap<Specification, SpecificationEditViewModel>().ReverseMap();
            CreateMap<Specification, SelectSpecificationViewModel>().ReverseMap();
            CreateMap<SpecificationEditViewModel, SpecificationDetailsViewModel>().ReverseMap();

        }
    }
}