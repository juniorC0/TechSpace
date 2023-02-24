using AutoMapper;
using TechSpace.Application.Dtos;
using TechSpace.Domain;

namespace TechSpace.Application.Profiles
{
    public class ProductionPremiseProfile : Profile
    {
        public ProductionPremiseProfile()
        {
            CreateMap<ProductionPremiseDto, ProductionPremise>();
            CreateMap<ProductionPremise, ProductionPremiseDto>();
        }
    }
}
