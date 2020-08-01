using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public class MethodRepository:IRepository<Method>
    {
        private DbServiceContext _dbServiceContext;
        
        public MethodRepository(DbServiceContext dbServiceContext)
        {
            _dbServiceContext = dbServiceContext;
        }
        
        public Task<List<Method>> GetAll()
        {
            return _dbServiceContext.Methods.ToListAsync();
        }

        public ValueTask<Method> Get(int id)
        {
            return _dbServiceContext.Methods.FindAsync(id);
        }

        public ValueTask<EntityEntry<Method>> Create(Method item)
        {
            return _dbServiceContext.Methods.AddAsync(item);
        }

        public void Update(Method item)
        {
            _dbServiceContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var method = _dbServiceContext.Methods.Find(id);
            if (method != null)
                _dbServiceContext.Methods.Remove(method);
        }
    }
}