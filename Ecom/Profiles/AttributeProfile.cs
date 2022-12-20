using AutoMapper;
using DB.Models;
using Ecom.Models;
using Attribute = DB.Models.Attribute;

namespace Ecom.Profiles
{
    public class AttributeProfile : Profile
    {
        public AttributeProfile()
        {
            CreateMap<Attribute, AttributeDetailsViewModel>().ReverseMap();
            CreateMap<Attribute, AttributeEditViewModel>().ReverseMap();
            CreateMap<AttributeEditViewModel, AttributeDetailsViewModel>().ReverseMap();
        }
    }
}