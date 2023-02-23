using AutoMapper;
using TechSpace.Application.Dtos;
using TechSpace.Application.Interfaces;
using TechSpace.Domain;

namespace TechSpace.Application.Resolvers
{
    public class ProductionPremiseResolver : IValueResolver<EquipmentPlacementContractDto, EquipmentPlacementContract, ProductionPremise>
    {
        private readonly IProductionPremiseRepository _productionPremiseRepository;

        public ProductionPremiseResolver(IProductionPremiseRepository productionPremiseRepository)
        {
            _productionPremiseRepository = productionPremiseRepository;
        }

        public ProductionPremise Resolve(EquipmentPlacementContractDto source, EquipmentPlacementContract destination, 
            ProductionPremise destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.ProductionPremiseCode))
            {
                throw new ArgumentException("ProductionPremiseCode cannot be null or empty.");
            }

            var productionPremise = _productionPremiseRepository.GetByCodeAsync(source.ProductionPremiseCode).Result;

            if (productionPremise == null)
            {
                throw new ArgumentException($"Invalid ProductionPremise code: {source.ProductionPremiseCode}");
            }

            return productionPremise;
        }
    }

}
