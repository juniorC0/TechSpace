using AutoMapper;
using MediatR;
using TechSpace.Application.Interfaces;

namespace TechSpace.Application.EquipmentPlacementContracts.Queries
{
    public class GetAllEquipmentPlacementContractsQuery : IRequest<IEnumerable<GetAllEquipmentPlacementContractsQuery>>
    {
        public string ProductionPremiseName { get; set; }
        public string TypeOfTechnologicalEquipmentName { get; set; }
        public int NumberOfEquipmentUnits { get; set; }
    }

    public class GetAllEquipmentPlacementContractsQueryHandler : IRequestHandler<GetAllEquipmentPlacementContractsQuery,
        IEnumerable<GetAllEquipmentPlacementContractsQuery>>
    {
        private readonly IEquipmentPlacementContractRepository _repository;
        private readonly IMapper _mapper;


        public GetAllEquipmentPlacementContractsQueryHandler(IEquipmentPlacementContractRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<GetAllEquipmentPlacementContractsQuery>> Handle(GetAllEquipmentPlacementContractsQuery request, CancellationToken cancellationToken)
        {
            var contracts = await _repository.GetAllAsync();

            var contractDtos = _mapper.Map<IEnumerable<GetAllEquipmentPlacementContractsQuery>>(contracts);

            return contractDtos;
        }
    }
}
