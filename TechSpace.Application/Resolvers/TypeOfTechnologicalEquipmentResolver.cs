using AutoMapper;
using TechSpace.Application.Dtos;
using TechSpace.Application.EquipmentPlacementContracts.Commands;
using TechSpace.Application.Interfaces;
using TechSpace.Domain;

namespace TechSpace.Application.Resolvers
{
    public class TypeOfTechnologicalEquipmentResolver : IValueResolver<CreateEquipmentPlacementContractCommand,
       EquipmentPlacementContractDto, TypeOfTechnologicalEquipment>
    {
        private readonly ITypeOfTechnologicalEquipmentRepository _typeOfTechnologicalEquipmentRepository;


        public TypeOfTechnologicalEquipmentResolver(ITypeOfTechnologicalEquipmentRepository typeOfTechnologicalEquipmentRepository)
        {
            _typeOfTechnologicalEquipmentRepository = typeOfTechnologicalEquipmentRepository;
        }


        public TypeOfTechnologicalEquipment Resolve(CreateEquipmentPlacementContractCommand source,
            EquipmentPlacementContractDto destination, TypeOfTechnologicalEquipment destMember,
            ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.TypeOfTechnologicalEquipmentCode))
            {
                throw new ArgumentException("TypeOfTechnologicalEquipmentCode cannot be null or empty.");
            }

            var typeOfTechnologicalEquipment = _typeOfTechnologicalEquipmentRepository
                .GetByCodeAsync(source.TypeOfTechnologicalEquipmentCode).Result;

            if (typeOfTechnologicalEquipment == null)
            {
                throw new ArgumentException($"Invalid TypeOfTechnologicalEquipment code: {source.TypeOfTechnologicalEquipmentCode}");
            }

            return typeOfTechnologicalEquipment;
        }
    }
}
