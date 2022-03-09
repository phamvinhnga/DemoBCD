using System;
using System.Threading.Tasks;

namespace UnitOfWork.Configurations.InterfaceRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChange();
        Task<int> SaveChangeAsync();
    }
}
