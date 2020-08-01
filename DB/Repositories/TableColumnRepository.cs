using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public class TableColumnRepository:IRepository<TableColumn>
    {
        private DbServiceContext _dbServiceContext;
        
        public TableColumnRepository(DbServiceContext dbServiceContext)
        {
            _dbServiceContext = dbServiceContext;
        }
        
        public Task<List<TableColumn>> GetAll()
        {
            return _dbServiceContext.TablesColumns.ToListAsync();
        }

        public ValueTask<TableColumn> Get(int id)
        {
            return _dbServiceContext.TablesColumns.FindAsync(id);
        }

        public ValueTask<EntityEntry<TableColumn>> Create(TableColumn item)
        {
            return _dbServiceContext.TablesColumns.AddAsync(item);
        }

        public void Update(TableColumn item)
        {
            _dbServiceContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var project = _dbServiceContext.Projects.Find(id);
            if (project != null)
                _dbServiceContext.Projects.Remove(project);
        }
    }
}