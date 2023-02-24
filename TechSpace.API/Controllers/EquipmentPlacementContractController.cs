using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechSpace.Application.Dtos;
using TechSpace.Application.EquipmentPlacementContracts.Commands;
using TechSpace.Application.Interfaces;
using TechSpace.Domain;

namespace TechSpace.API.Controllers
{
    [Route("api/equipment-placement-contract-controller")]
    [ApiController]
    public class EquipmentPlacementContractController : ControllerBase
    {
        private readonly IEntityRepository<EquipmentPlacementContract> _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public EquipmentPlacementContractController(IEntityRepository<EquipmentPlacementContract> repository, 
            IMapper mapper, IMediator mediator)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipmentPlacementContract(CreateEquipmentPlacementContractCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return Ok();
            }
            catch (AutoMapperMappingException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        //[HttpGet]
        //public IActionResult<IEnumerable<EquipmentPlacementContractDto>> GetContracts()
        //{
        //    var contracts = _repository.
        //    return Ok();
        //}
    }
}
