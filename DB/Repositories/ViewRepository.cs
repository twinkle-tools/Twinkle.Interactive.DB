using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public class ViewRepository:IRepository<View>
    {
        private DbServiceContext _dbServiceContext;
        
        public ViewRepository(DbServiceContext dbServiceContext)
        {
            _dbServiceContext = dbServiceContext;
        }
        
        public Task<List<View>> GetAll()
        {
            return _dbServiceContext.Views.ToListAsync();
        }

        public ValueTask<View> Get(int id)
        {
            return _dbServiceContext.Views.FindAsync(id);
        }

        public ValueTask<EntityEntry<View>> Create(View item)
        {
            return _dbServiceContext.Views.AddAsync(item);
        }

        public void Update(View item)
        {
            _dbServiceContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var views = _dbServiceContext.Views.Find(id);
            if (views != null)
                _dbServiceContext.Views.Remove(views);
        }
    }
}