using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public class ViewDefinitionCriteriaParamRepository:IRepository<ViewDefinitionCriteriaParam>
    {
        private DbServiceContext _dbServiceContext;
        
        public ViewDefinitionCriteriaParamRepository(DbServiceContext dbServiceContext)
        {
            _dbServiceContext = dbServiceContext;
        }
        
        public Task<List<ViewDefinitionCriteriaParam>> GetAll()
        {
            return _dbServiceContext.ViewDefinitionCriteriaParams.ToListAsync();
        }

        public ValueTask<ViewDefinitionCriteriaParam> Get(int id)
        {
            return _dbServiceContext.ViewDefinitionCriteriaParams.FindAsync(id);
        }

        public ValueTask<EntityEntry<ViewDefinitionCriteriaParam>> Create(ViewDefinitionCriteriaParam item)
        {
            return _dbServiceContext.ViewDefinitionCriteriaParams.AddAsync(item);
        }

        public void Update(ViewDefinitionCriteriaParam item)
        {
            _dbServiceContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var viewDefinitionCriteriaParams = _dbServiceContext.ViewDefinitionCriteriaParams.Find(id);
            if (viewDefinitionCriteriaParams != null)
                _dbServiceContext.ViewDefinitionCriteriaParams.Remove(viewDefinitionCriteriaParams);
        }
    }
}