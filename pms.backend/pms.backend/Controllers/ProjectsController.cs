using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.contracts;

namespace pms.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly IRepository<Project> serviceProject;

        public ProjectsController(IRepository<Project> serviceProject)
        {
            this.serviceProject = serviceProject;
        }

        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProjects()
        {
            return Ok(serviceProject.GetAll());
        }

    }
}
