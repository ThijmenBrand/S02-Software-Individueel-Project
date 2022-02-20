using Microsoft.AspNetCore.Mvc;
using BusinessAccessLayer.services;

namespace pms.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly IServiceProject serviceProject;

        public ProjectsController(IServiceProject serviceProject)
        {
            this.serviceProject = serviceProject;
        }

        [HttpGet]
        public ActionResult<List<Project>> GetAllProjects()
        {
            return Ok(serviceProject.GetAllProjects());
        }

        [HttpPost]
        public ActionResult<List<Project>> AddProject(Project project)
        {
            serviceProject.AddProject(project);
            return Ok("Apple");
        }
    }
}
