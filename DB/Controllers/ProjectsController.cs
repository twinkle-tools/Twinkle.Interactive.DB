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
    public class ProjectsController: Controller
    {
        private DbUnitOfWork _dbUnitOfWork;
        
        public ProjectsController(DbUnitOfWork dbUnitOfWork)
        {
            _dbUnitOfWork = dbUnitOfWork;
        }
        
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project projectItem)
        {
            await _dbUnitOfWork.Projects.Create(projectItem);
            await _dbUnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = projectItem.Id }, projectItem);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProject()
        {
            return await _dbUnitOfWork.Projects.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var projectItem = await _dbUnitOfWork.Projects.Get(id);

            if (projectItem == null)
            {
                return NotFound();
            }

            return projectItem;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project projectItem)
        {
            if (id != projectItem.Id)
            {
                return BadRequest();
            }

            var projectForUpdater = await _dbUnitOfWork.Projects.Get(projectItem.Id);

            if (projectForUpdater != null)
            {
                projectForUpdater.Id = projectItem.Id;
                projectForUpdater.Name = projectItem.Name;
                projectForUpdater.DbName = projectItem.DbName;
                projectForUpdater.IsActive = projectItem.IsActive;
                projectForUpdater.NameTestDll = projectItem.NameTestDll;
                projectForUpdater.PathToProject = projectItem.PathToProject;
                projectForUpdater.PathToExportViews = projectItem.PathToExportViews;
            
                _dbUnitOfWork.Projects.Update(projectForUpdater);
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
                if (!ProjectItemExists(id))
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
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            var projectItem = await _dbUnitOfWork.Projects.Get(id);
            if (projectItem == null)
            {
                return NotFound();
            }

            _dbUnitOfWork.Projects.Delete(id);
            await _dbUnitOfWork.SaveChangesAsync();

            return projectItem;
        }
        
        private bool ProjectItemExists(int id)
        {
            return _dbUnitOfWork.Projects.GetAll().Result.Any(e => e.Id == id);
        }
        
    }
}