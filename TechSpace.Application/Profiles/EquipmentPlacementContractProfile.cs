using AutoMapper;
using TechSpace.Application.Dtos;
using TechSpace.Application.Resolvers;
using TechSpace.Domain;

namespace TechSpace.Application.Profiles
{
    public class EquipmentPlacementContractProfile : Profile
    {
        public EquipmentPlacementContractProfile()
        {
            CreateMap<EquipmentPlacementContractDto, EquipmentPlacementContract>()
                .ForMember(dest => dest.ProductionPremise, opt => opt.MapFrom<ProductionPremiseResolver>())
                .ForMember(dest => dest.TypeOfTechnologicalEquipment, opt => opt.MapFrom<TypeOfTechnologicalEquipmentResolver>());

        }
    } 
}
