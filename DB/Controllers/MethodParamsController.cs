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
    public class MethodParamsController: Controller
    {
        private DbUnitOfWork _dbUnitOfWork;
        
        public MethodParamsController(DbUnitOfWork dbUnitOfWork)
        {
            _dbUnitOfWork = dbUnitOfWork;
        }
        
        [HttpPost]
        public async Task<ActionResult<MethodParam>> PostMethodParam(MethodParam methodParamItem)
        {
            await _dbUnitOfWork.MethodParams.Create(methodParamItem);
            await _dbUnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMethodParam), new { id = methodParamItem.Id }, methodParamItem);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MethodParam>>> GetAllMethodsParam()
        {
            return await _dbUnitOfWork.MethodParams.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<MethodParam>> GetMethodParam(int id)
        {
            var methodParamlItem = await _dbUnitOfWork.MethodParams.Get(id);

            if (methodParamlItem == null)
            {
                return NotFound();
            }

            return methodParamlItem;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMethodParam(int id, MethodParam methodParamItem)
        {
            if (id != methodParamItem.Id)
            {
                return BadRequest();
            }

            _dbUnitOfWork.MethodParams.Update(methodParamItem);

            try
            {
                await _dbUnitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MethodParamItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MethodParam>> DeleteMethodParam(int id)
        {
            var methodParamItem = await _dbUnitOfWork.MethodParams.Get(id);
            if (methodParamItem == null)
            {
                return NotFound();
            }

            _dbUnitOfWork.MethodParams.Delete(id);
            await _dbUnitOfWork.SaveChangesAsync();

            return methodParamItem;
        }
        
        private bool MethodParamItemExists(int id)
        {
            return _dbUnitOfWork.MethodParams.GetAll().Result.Any(e => e.Id == id);
        }
    }
}