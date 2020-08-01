using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        ValueTask<T> Get(int id);
        ValueTask<EntityEntry<T>> Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}