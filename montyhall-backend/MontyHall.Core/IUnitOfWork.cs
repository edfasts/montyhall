using System;
using System.Threading.Tasks;
using MontyHall.Core.Repositories;

namespace MontyHall.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ISimulationRepository Simulations { get; }
        Task<int> CommitAsync();
    }
}