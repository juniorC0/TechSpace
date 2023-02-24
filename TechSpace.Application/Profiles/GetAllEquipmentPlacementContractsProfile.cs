using AutoMapper;
using TechSpace.Application.EquipmentPlacementContracts.Queries;
using TechSpace.Domain;

namespace TechSpace.Application.Profiles
{
    public class GetAllEquipmentPlacementContractsProfile : Profile
    {
        public GetAllEquipmentPlacementContractsProfile()
        {
            CreateMap<EquipmentPlacementContract, GetAllEquipmentPlacementContractsQuery>()
                .ForMember(dest => dest.ProductionPremiseName, opt => opt.MapFrom(src =>
                    src.ProductionPremise.Name))
                .ForMember(dest => dest.TypeOfTechnologicalEquipmentName, opt => opt.MapFrom(src =>
                    src.TypeOfTechnologicalEquipment.Name));
        }
    }
}
