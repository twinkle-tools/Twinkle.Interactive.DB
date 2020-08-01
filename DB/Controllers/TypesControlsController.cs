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
    public class TypesControlsController: Controller
    {
        private DbUnitOfWork _dbUnitOfWork;
        
        public TypesControlsController(DbUnitOfWork dbUnitOfWork)
        {
            _dbUnitOfWork = dbUnitOfWork;
        }
        
        [HttpPost]
        public async Task<ActionResult<TypeControl>> PostTypeControl(TypeControl typeControlItem)
        {
            await _dbUnitOfWork.TypesControls.Create(typeControlItem);
            await _dbUnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTypeControl), new { id = typeControlItem.Id }, typeControlItem);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeControl>>> GetAllTypesControls()
        {
            return await _dbUnitOfWork.TypesControls.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeControl>> GetTypeControl(int id)
        {
            var typeControlItem = await _dbUnitOfWork.TypesControls.Get(id);

            if (typeControlItem == null)
            {
                return NotFound();
            }

            return typeControlItem;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeControl(int id, TypeControl typeControlItem)
        {
            if (id != typeControlItem.Id)
            {
                return BadRequest();
            }

            var typeControlForUpdate = await _dbUnitOfWork.TypesControls.Get(typeControlItem.Id);

            if (typeControlForUpdate != null)
            {
                typeControlForUpdate.Id = typeControlItem.Id;
                typeControlForUpdate.Alias = typeControlItem.Alias;
                typeControlForUpdate.ProjectId = typeControlItem.ProjectId;
            
                _dbUnitOfWork.TypesControls.Update(typeControlForUpdate);
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
                if (!TypeControlItemExists(id))
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
        public async Task<ActionResult<TypeControl>> DeleteTypeControl(int id)
        {
            var typeControlItem = await _dbUnitOfWork.TypesControls.Get(id);
            if (typeControlItem == null)
            {
                return NotFound();
            }

            _dbUnitOfWork.TypesControls.Delete(id);
            await _dbUnitOfWork.SaveChangesAsync();

            return typeControlItem;
        }
        
        private bool TypeControlItemExists(int id)
        {
            return _dbUnitOfWork.TypesControls.GetAll().Result.Any(e => e.Id == id);
        }
        
    }
}