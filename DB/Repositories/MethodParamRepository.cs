using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public class MethodParamRepository:IRepository<MethodParam>
    {
        private DbServiceContext _dbServiceContext;
        
        public MethodParamRepository(DbServiceContext dbServiceContext)
        {
            _dbServiceContext = dbServiceContext;
        }
        
        public Task<List<MethodParam>> GetAll()
        {
            return _dbServiceContext.MethodsParams.ToListAsync();
        }

        public ValueTask<MethodParam> Get(int id)
        {
            return _dbServiceContext.MethodsParams.FindAsync(id);
        }

        public ValueTask<EntityEntry<MethodParam>> Create(MethodParam item)
        {
            return _dbServiceContext.MethodsParams.AddAsync(item);
        }

        public void Update(MethodParam item)
        {
            _dbServiceContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var methodParam = _dbServiceContext.MethodsParams.Find(id);
            if (methodParam != null)
                _dbServiceContext.MethodsParams.Remove(methodParam);
        }
    }
}