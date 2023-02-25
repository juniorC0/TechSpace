using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechSpace.Application.EquipmentPlacementContracts.Commands;
using TechSpace.Application.EquipmentPlacementContracts.Queries;

namespace TechSpace.API.Controllers
{
    [Route("api/equipment-placement-contract-controller")]
    [ApiController]
    [Authorize]
    public class EquipmentPlacementContractController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public EquipmentPlacementContractController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IEnumerable<GetAllEquipmentPlacementContractsQuery>> GetAllEquipmentPlacementContracts()
        {
            var allEquipmentPlacementContracts = await _mediator.Send(new GetAllEquipmentPlacementContractsQuery());
            return allEquipmentPlacementContracts;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipmentPlacementContract(CreateEquipmentPlacementContractCommand request)
        {
            var apiKey = Request.Headers["ApiKey"];
            if (!AddApiKey(apiKey))
            {
                return Unauthorized();
            }

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

        private bool AddApiKey(string apiKey)
        {
            var configuredApiKey = _configuration.GetValue<string>("ApiKey");

            if (apiKey != configuredApiKey)
            {
                return false;
            }

            return true;
        }
    }
}
