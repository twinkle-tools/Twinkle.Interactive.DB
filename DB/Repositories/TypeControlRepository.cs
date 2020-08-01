using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public class TypeControlRepository:IRepository<TypeControl>
    {
        private DbServiceContext _dbServiceContext;
        
        public TypeControlRepository(DbServiceContext dbServiceContext)
        {
            _dbServiceContext = dbServiceContext;
        }
        
        public Task<List<TypeControl>> GetAll()
        {
            return _dbServiceContext.TypesControls.ToListAsync();
        }

        public ValueTask<TypeControl> Get(int id)
        {
            return _dbServiceContext.TypesControls.FindAsync(id);
        }

        public ValueTask<EntityEntry<TypeControl>> Create(TypeControl item)
        {
            return _dbServiceContext.TypesControls.AddAsync(item);
        }

        public void Update(TypeControl item)
        {
            _dbServiceContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var typeControl = _dbServiceContext.TypesControls.Find(id);
            if (typeControl != null)
                _dbServiceContext.TypesControls.Remove(typeControl);
        }
    }
}