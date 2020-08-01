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
    public class MethodsController: Controller
    {
        private DbUnitOfWork _dbUnitOfWork;
        
        public MethodsController(DbUnitOfWork dbUnitOfWork)
        {
            _dbUnitOfWork = dbUnitOfWork;
        }
        
        [HttpPost]
        public async Task<ActionResult<Method>> PostMethod(Method methodItem)
        {
            await _dbUnitOfWork.Methods.Create(methodItem);
            await _dbUnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMethod), new { id = methodItem.Id }, methodItem);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Method>>> GetAllMethods()
        {
            return await _dbUnitOfWork.Methods.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Method>> GetMethod(int id)
        {
            var methodItem = await _dbUnitOfWork.Methods.Get(id);

            if (methodItem == null)
            {
                return NotFound();
            }

            return methodItem;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMethod(int id, Method methodItem)
        {
            if (id != methodItem.Id)
            {
                return BadRequest();
            }

            var methodForUpdate = await _dbUnitOfWork.Methods.Get(methodItem.Id);

            if (methodForUpdate != null)
            {
                methodForUpdate.Id = methodItem.Id;
                methodForUpdate.Alias = methodItem.Alias;
                methodForUpdate.ProjectId = methodItem.ProjectId;
                methodForUpdate.Deprecated = methodItem.Deprecated;
                methodForUpdate.Info = methodItem.Info;
                methodForUpdate.CommonMethod = methodItem.CommonMethod;
                methodForUpdate.IsActive = methodItem.IsActive;
            
                _dbUnitOfWork.Methods.Update(methodForUpdate);
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
                if (!MethodItemExists(id))
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
        public async Task<ActionResult<Method>> DeleteMethod(int id)
        {
            var methodItem = await _dbUnitOfWork.Methods.Get(id);
            if (methodItem == null)
            {
                return NotFound();
            }

            _dbUnitOfWork.Methods.Delete(id);
            await _dbUnitOfWork.SaveChangesAsync();

            return methodItem;
        }
        
        private bool MethodItemExists(int id)
        {
            return _dbUnitOfWork.Methods.GetAll().Result.Any(e => e.Id == id);
        }
        
    }
}