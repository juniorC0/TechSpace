using AutoMapper;
using TechSpace.Application.Dtos;
using TechSpace.Application.EquipmentPlacementContracts.Commands;
using TechSpace.Application.Resolvers;
using TechSpace.Domain;

namespace TechSpace.Application.Profiles
{
    public class EquipmentPlacementContractProfile : Profile
    {
        public EquipmentPlacementContractProfile()
        {
            CreateMap<CreateEquipmentPlacementContractCommand, EquipmentPlacementContractDto>()
                .ForMember(dest => dest.ProductionPremise, opt => opt.MapFrom<ProductionPremiseResolver>())
                .ForMember(dest => dest.TypeOfTechnologicalEquipment, opt => opt.MapFrom<TypeOfTechnologicalEquipmentResolver>());

            CreateMap<EquipmentPlacementContractDto, EquipmentPlacementContract>();
        }
    } 
}
