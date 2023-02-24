using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechSpace.Application.Dtos;
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

        public EquipmentPlacementContractController(IEntityRepository<EquipmentPlacementContract> repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateEquipmentPlacementContract([FromBody] EquipmentPlacementContractDto dto)
        {
            try
            {
                var contract = _mapper.Map<EquipmentPlacementContract>(dto);
                _repository.AddAsync(contract);
                _repository.SaveChangesAsync();
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
    }
}
