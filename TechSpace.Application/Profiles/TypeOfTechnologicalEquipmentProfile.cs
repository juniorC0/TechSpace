using AutoMapper;
using TechSpace.Application.Dtos;
using TechSpace.Domain;

namespace TechSpace.Application.Profiles
{
    public class TypeOfTechnologicalEquipmentProfile : Profile
    {
        public TypeOfTechnologicalEquipmentProfile()
        {
            CreateMap<TypeOfTechnologicalEquipmentDto, TypeOfTechnologicalEquipment>();
        }
    }
}
