using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public class ViewDefinitionCriteriaRepository:IRepository<ViewDefinitionCriteria>
    {
        private DbServiceContext _dbServiceContext;
        
        public ViewDefinitionCriteriaRepository(DbServiceContext dbServiceContext)
        {
            _dbServiceContext = dbServiceContext;
        }
        
        public Task<List<ViewDefinitionCriteria>> GetAll()
        {
            return _dbServiceContext.ViewDefinitionCriteria.ToListAsync();
        }

        public ValueTask<ViewDefinitionCriteria> Get(int id)
        {
            return _dbServiceContext.ViewDefinitionCriteria.FindAsync(id);
        }

        public ValueTask<EntityEntry<ViewDefinitionCriteria>> Create(ViewDefinitionCriteria item)
        {
            return _dbServiceContext.ViewDefinitionCriteria.AddAsync(item);
        }

        public void Update(ViewDefinitionCriteria item)
        {
            _dbServiceContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var viewDefinitionCriteria = _dbServiceContext.ViewDefinitionCriteria.Find(id);
            if (viewDefinitionCriteria != null)
                _dbServiceContext.ViewDefinitionCriteria.Remove(viewDefinitionCriteria);
        }
    }
}