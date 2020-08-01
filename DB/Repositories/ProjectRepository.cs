using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public class ProjectRepository:IRepository<Project>
    {
        private DbServiceContext _dbServiceContext;
        
        public ProjectRepository(DbServiceContext dbServiceContext)
        {
            _dbServiceContext = dbServiceContext;
        }
        
        public Task<List<Project>> GetAll()
        {
            return _dbServiceContext.Projects.ToListAsync();
        }

        public ValueTask<Project> Get(int id)
        {
            return _dbServiceContext.Projects.FindAsync(id);
        }

        public ValueTask<EntityEntry<Project>> Create(Project item)
        {
            return _dbServiceContext.Projects.AddAsync(item);
        }

        public void Update(Project item)
        {
            _dbServiceContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var project = _dbServiceContext.Projects.FindAsync(id);
            if (project.Result != null)
                _dbServiceContext.Projects.Remove(project.Result);
        }
    }
}