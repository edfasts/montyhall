using Microsoft.EntityFrameworkCore;
using MontyHall.Core.Models;
using MontyHall.Core.Repositories;

namespace MontyHall.Data.Repositories
{
    public class SimulationRepository : Repository<Simulation>, ISimulationRepository
    {
        public SimulationRepository(MontyHallDbContext context) : base(context)
        {
            
        }
    }
}