using System.Collections.Generic;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DBService.Repositories
{
    public class TreatmentOptionRepository:IRepository<TreatmentOption>
    {
        private DbServiceContext _dbServiceContext;
        
        public TreatmentOptionRepository(DbServiceContext dbServiceContext)
        {
            _dbServiceContext = dbServiceContext;
        }
        
        public Task<List<TreatmentOption>> GetAll()
        {
            return _dbServiceContext.TreatmentsOptions.ToListAsync();
        }

        public ValueTask<TreatmentOption> Get(int id)
        {
            return _dbServiceContext.TreatmentsOptions.FindAsync(id);
        }

        public ValueTask<EntityEntry<TreatmentOption>> Create(TreatmentOption item)
        {
            return _dbServiceContext.TreatmentsOptions.AddAsync(item);
        }

        public void Update(TreatmentOption item)
        {
            _dbServiceContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var treatmentOption = _dbServiceContext.TreatmentsOptions.Find(id);
            if (treatmentOption != null)
                _dbServiceContext.TreatmentsOptions.Remove(treatmentOption);
        }
    }
}