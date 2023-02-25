using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using TechSpace.API.Controllers;
using TechSpace.Application.EquipmentPlacementContracts.Commands;
using TechSpace.Application.EquipmentPlacementContracts.Queries;

namespace TechSpace.Tests
{
    [TestClass]
    public class EquipmentPlacementContractControllerTests
    {
        private EquipmentPlacementContractController _controller;
        private Mock<IMediator> _mediatorMock;
        private Mock<IConfiguration> _configurationMock;

        [TestInitialize]
        public void Initialize()
        {
            _mediatorMock = new Mock<IMediator>();
            _configurationMock = new Mock<IConfiguration>();
            _controller = new EquipmentPlacementContractController(_mediatorMock.Object, _configurationMock.Object);
        }

        [TestMethod]
        public async Task GetAllEquipmentPlacementContracts_Returns_All_Contracts()
        {
            var expectedContracts = new List<GetAllEquipmentPlacementContractsQuery>();

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllEquipmentPlacementContractsQuery>(), default)).ReturnsAsync(expectedContracts);

            var result = await _controller.GetAllEquipmentPlacementContracts();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IEnumerable<GetAllEquipmentPlacementContractsQuery>));
            Assert.AreEqual(expectedContracts, result);
        }

        [TestMethod]
        public async Task CreateEquipmentPlacementContract_ValidRequest_ReturnsOk()
        {
            // Arrange
            var request = new CreateEquipmentPlacementContractCommand();

            // Act
            var result = await _controller.CreateEquipmentPlacementContract(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task CreateEquipmentPlacementContract_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var request = new CreateEquipmentPlacementContractCommand();
            _mediatorMock.Setup(x => x.Send(request, CancellationToken.None)).Throws(new AutoMapperMappingException("Mapping exception"));

            // Act
            var result = await _controller.CreateEquipmentPlacementContract(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task CreateEquipmentPlacementContract_InternalServerError_ReturnsStatusCode500()
        {
            // Arrange
            var request = new CreateEquipmentPlacementContractCommand();
            _mediatorMock.Setup(x => x.Send(request, CancellationToken.None)).Throws(new Exception());

            // Act
            var result = await _controller.CreateEquipmentPlacementContract(request);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            Assert.AreEqual(500, (result as ObjectResult)?.StatusCode);
        }

        [TestMethod]
        public async Task CreateEquipmentPlacementContract_Mapping_Exception_Returns_BadRequest()
        {
            // Arrange
            var request = new CreateEquipmentPlacementContractCommand();
            _mediatorMock.Setup(m => m.Send(request, default(CancellationToken))).ThrowsAsync(new AutoMapperMappingException("Mapping exception"));

            // Act
            var result = await _controller.CreateEquipmentPlacementContract(request);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}