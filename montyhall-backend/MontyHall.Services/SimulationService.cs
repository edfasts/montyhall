using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MontyHall.Core;
using MontyHall.Core.Models;
using MontyHall.Core.Services;

namespace MontyHall.Services
{
    public class SimulationService : ISimulationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SimulationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Simulation>> GetAllSimulations()
        {
            return await _unitOfWork.Simulations.GetAllAsync();
        }

        public async Task<Simulation> GetSimulationById(int id)
        {
            return await _unitOfWork.Simulations.GetByIdAsync(id);
        }

        public async Task<Simulation> CreateSimulation(int numberOfRounds, bool changeDoor)
        {
            if (numberOfRounds < 1) 
                throw new ArgumentException($"{nameof(numberOfRounds)} must be greater than zero");
            
            var simulation = new Simulation()
            {
                NumberOfRounds = numberOfRounds,
                ChangeDoor = changeDoor
            };

            RunSimulation(simulation);
            await _unitOfWork.Simulations.AddAsync(simulation);
            await _unitOfWork.CommitAsync();
            
            return simulation;
        }

        private static void RunSimulation(Simulation simulation)
        {
            var random = new Random();
            for (var i = 0; i < simulation.NumberOfRounds; i++)
            {
                var doorWithCar = random.Next(0, 3);
                var selectedDoor = random.Next(0, 3);
                if (selectedDoor == doorWithCar && !simulation.ChangeDoor
                    || selectedDoor != doorWithCar && simulation.ChangeDoor)
                    simulation.SuccessfulRounds++;
            }
        }
    }
}