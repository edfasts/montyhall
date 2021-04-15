using System;
using System.Threading.Tasks;
using FluentAssertions;
using MontyHall.Core;
using MontyHall.Core.Repositories;
using MontyHall.Services;
using Moq;
using Xunit;

namespace MontyHall.Tests
{
    public class SimulationServiceTest
    {
        [Fact]
        public async Task CreateSimulation_With100Rounds_ShouldReturnSimulationWithSuccessfulRounds()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Simulations).Returns(Mock.Of<ISimulationRepository>);
            var simulationService = new SimulationService(unitOfWork.Object);

            var simulation = await simulationService.CreateSimulation(100, true);

            simulation.SuccessfulRounds.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public async Task CreateSimulation_With0Rounds_ShouldThrowArgumentException()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(uow => uow.Simulations).Returns(Mock.Of<ISimulationRepository>);
            var simulationService = new SimulationService(unitOfWork.Object);

            Func<Task> f = async () => await simulationService.CreateSimulation(0, true);
            await f.Should().ThrowAsync<ArgumentException>();
        }
    }
}