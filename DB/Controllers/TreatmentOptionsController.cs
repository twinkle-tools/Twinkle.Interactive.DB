using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBService.Domain.Models;
using DBService.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreatmentOptionsController: Controller
    {
        private DbUnitOfWork _dbUnitOfWork;
        
        public TreatmentOptionsController(DbUnitOfWork dbUnitOfWork)
        {
            _dbUnitOfWork = dbUnitOfWork;
        }
        
        [HttpPost]
        public async Task<ActionResult<TreatmentOption>> PostTreatmentOption(TreatmentOption treatmentOptionItem)
        {
            await _dbUnitOfWork.TreatmentOptions.Create(treatmentOptionItem);
            await _dbUnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTreatmentOption), new { id = treatmentOptionItem.Id }, treatmentOptionItem);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TreatmentOption>>> GetAllTreatmentOptions()
        {
            return await _dbUnitOfWork.TreatmentOptions.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TreatmentOption>> GetTreatmentOption(int id)
        {
            var treatmentOptionItem = await _dbUnitOfWork.TreatmentOptions.Get(id);

            if (treatmentOptionItem == null)
            {
                return NotFound();
            }

            return treatmentOptionItem;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreatmentOption(int id, TreatmentOption treatmentOptionItem)
        {
            if (id != treatmentOptionItem.Id)
            {
                return BadRequest();
            }

            var treatmentOptionForUpdate = await _dbUnitOfWork.TreatmentOptions.Get(treatmentOptionItem.Id);

            if (treatmentOptionForUpdate != null)
            {
                treatmentOptionForUpdate.Id = treatmentOptionItem.Id;
                treatmentOptionForUpdate.Signature = treatmentOptionItem.Signature;
                treatmentOptionForUpdate.Type = treatmentOptionItem.Type;
                treatmentOptionForUpdate.ProjectId = treatmentOptionItem.ProjectId;
            
                _dbUnitOfWork.TreatmentOptions.Update(treatmentOptionForUpdate);
            }
            else
            {
                return NotFound();
            }

            try
            {
                await _dbUnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreatmentOptionItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TreatmentOption>> DeleteTreatmentOption(int id)
        {
            var treatmentOptionItem = await _dbUnitOfWork.TreatmentOptions.Get(id);
            if (treatmentOptionItem == null)
            {
                return NotFound();
            }

            _dbUnitOfWork.TreatmentOptions.Delete(id);
            await _dbUnitOfWork.SaveChangesAsync();

            return treatmentOptionItem;
        }
        
        private bool TreatmentOptionItemExists(int id)
        {
            return _dbUnitOfWork.TreatmentOptions.GetAll().Result.Any(e => e.Id == id);
        }
        
    }
}