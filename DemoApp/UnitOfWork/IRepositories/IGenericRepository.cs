using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitOfWork.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Guid id);
        void Add(T entity);
        void Update(T entity);
        bool Remove(Guid id);

        //async method
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<bool> RemoveAsync(Guid id);        
    }
}
