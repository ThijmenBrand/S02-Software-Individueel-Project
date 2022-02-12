using Microsoft.AspNetCore.Mvc;
using pms.backend.Models;

namespace pms.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        
        private readonly DataContext _context;

        public ProjectsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectsModel>>> GetProjects()
        {
            return Ok(await _context.projectsModel.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProjectsModel>>> Get(int id)
        {
            var project = await _context.projectsModel.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProjectsModel>>> AddProject([FromBody] ProjectsModel project)
        {
            _context.projectsModel.Add(project);
            await _context.SaveChangesAsync();

            return Ok(await _context.projectsModel.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ProjectsModel>>> UpdateProject([FromBody] ProjectsModel updateData)
        {
            var project = await _context.projectsModel.FindAsync(updateData.ProjectId);
            if (project == null)
            {
                return NotFound();
            }

            project.ProjectName = updateData.ProjectName;
            project.ProjectDiscription = updateData.ProjectDiscription;

            await _context.SaveChangesAsync();

            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectsModel>>> Delete(int id)
        {
            var project = _context.projectsModel.Find(id);
            if(project == null)
            {
                return NoContent();
            }

            _context.projectsModel.Remove(project);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
