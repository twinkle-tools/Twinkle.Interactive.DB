using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public class ControlRepository:IRepository<Control>
    {
        private DbServiceContext _dbServiceContext;
        
        public ControlRepository(DbServiceContext dbServiceContext)
        {
            _dbServiceContext = dbServiceContext;
        }
        
        public Task<List<Control>> GetAll()
        {
            return _dbServiceContext.Controls.ToListAsync();
        }

        public ValueTask<Control> Get(int id)
        {
            return _dbServiceContext.Controls.FindAsync(id);
        }

        public ValueTask<EntityEntry<Control>> Create(Control item)
        {
            return _dbServiceContext.Controls.AddAsync(item);
        }

        public void Update(Control item)
        {
            _dbServiceContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var control = _dbServiceContext.Controls.Find(id);
            if (control != null)
                _dbServiceContext.Controls.Remove(control);
        }
    }
}