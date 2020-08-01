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
    public class ControlsController: Controller
    {
        private DbUnitOfWork _dbUnitOfWork;
        
        public ControlsController(DbUnitOfWork dbUnitOfWork)
        {
            _dbUnitOfWork = dbUnitOfWork;
        }
        
        [HttpPost]
        public async Task<ActionResult<Control>> PostControl(Control controlItem)
        {
            await _dbUnitOfWork.Controls.Create(controlItem);
            await _dbUnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetControl), new { id = controlItem.Id }, controlItem);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Control>>> GetAllControls()
        {
            return await _dbUnitOfWork.Controls.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Control>> GetControl(int id)
        {
            var controlItem = await _dbUnitOfWork.Controls.Get(id);

            if (controlItem == null)
            {
                return NotFound();
            }

            return controlItem;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControl(int id, Control controlItem)
        {
            if (id != controlItem.Id)
            {
                return BadRequest();
            }

            var controlForUpdate = await _dbUnitOfWork.Controls.Get(controlItem.Id);

            if (controlForUpdate != null)
            {
                controlForUpdate.Id = controlItem.Id;
                controlForUpdate.Alias = controlItem.Alias;
                controlForUpdate.Css = controlItem.Css;
                controlForUpdate.XPath = controlItem.XPath;
                controlForUpdate.ViewId = controlItem.ViewId;
                controlForUpdate.TypeControlId = controlItem.TypeControlId;
                controlForUpdate.IsActive = controlItem.IsActive;
            
                _dbUnitOfWork.Controls.Update(controlForUpdate);
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
                if (!ControlItemExists(id))
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
        public async Task<ActionResult<Control>> DeleteControl(int id)
        {
            var controlItem = await _dbUnitOfWork.Controls.Get(id);
            if (controlItem == null)
            {
                return NotFound();
            }

            _dbUnitOfWork.Controls.Delete(id);
            await _dbUnitOfWork.SaveChangesAsync();

            return controlItem;
        }
        
        private bool ControlItemExists(int id)
        {
            return _dbUnitOfWork.Controls.GetAll().Result.Any(e => e.Id == id);
        }
    }
}