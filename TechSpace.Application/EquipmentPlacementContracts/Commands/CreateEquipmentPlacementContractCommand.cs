using AutoMapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using TechSpace.Application.Dtos;
using TechSpace.Application.Interfaces;
using TechSpace.Domain;

namespace TechSpace.Application.EquipmentPlacementContracts.Commands
{
    public class CreateEquipmentPlacementContractCommand : IRequest<EquipmentPlacementContractDto>
    {
        [Required]
        public string ProductionPremiseCode { get; set; }
        [Required]
        public string TypeOfTechnologicalEquipmentCode { get; set; }

        public int NumberOfEquipmentUnits { get; set; }
    }

    public class CreateEquipmentPlacementContractCommandHandler : IRequestHandler<CreateEquipmentPlacementContractCommand,
        EquipmentPlacementContractDto>
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentPlacementContractRepository _repository;


        public CreateEquipmentPlacementContractCommandHandler(IMapper mapper, 
            IEquipmentPlacementContractRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        public async Task<EquipmentPlacementContractDto> Handle(CreateEquipmentPlacementContractCommand request, 
            CancellationToken cancellationToken)
        {
            var contractDto = _mapper.Map<EquipmentPlacementContractDto>(request);

            var contract = _mapper.Map<EquipmentPlacementContract>(contractDto);

            await _repository.AddAsync(contract);
            await _repository.SaveChangesAsync();

            return contractDto;
        }
    }
}
