using AutoMapper;
using TechSpace.Application.Dtos;
using TechSpace.Application.EquipmentPlacementContracts.Commands;
using TechSpace.Application.Interfaces;
using TechSpace.Domain;

public class ProductionPremiseResolver : IValueResolver<CreateEquipmentPlacementContractCommand, 
    EquipmentPlacementContractDto, ProductionPremise>
{
    private readonly IProductionPremiseRepository _productionPremiseRepository;


    public ProductionPremiseResolver(IProductionPremiseRepository productionPremiseRepository)
    {
        _productionPremiseRepository = productionPremiseRepository;
    }


    public ProductionPremise Resolve(CreateEquipmentPlacementContractCommand source, EquipmentPlacementContractDto destination,
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