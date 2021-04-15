using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MontyHall.Core.Models;

namespace MontyHall.Core.Services
{
    public interface ISimulationService
    {
        Task<IEnumerable<Simulation>> GetAllSimulations();
        Task<Simulation> GetSimulationById(int id);
        Task<Simulation> CreateSimulation(int numberOfRounds, bool changeDoor);
    }
}