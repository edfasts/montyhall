using System.Threading.Tasks;
using MontyHall.Core;
using MontyHall.Core.Models;
using MontyHall.Core.Repositories;
using MontyHall.Data.Repositories;

namespace MontyHall.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MontyHallDbContext _context;
        private SimulationRepository _simulationRepository;

        public UnitOfWork(MontyHallDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public ISimulationRepository Simulations => _simulationRepository ??= new SimulationRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}