using Microsoft.AspNetCore.Mvc;
using BusinessLayer.services.project;
using Microsoft.AspNetCore.Authorization;
using ApiLayer.Helpers;

namespace ApiLayer.Controllers
{
    [Authorize]
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
            return Ok(serviceProject.GetAllProjects(GetUserId.getUserId()));
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(Project project)
        {
            await serviceProject.AddProject(project, GetUserId.getUserId());
            return Ok(serviceProject.GetAllProjects(GetUserId.getUserId()));
        }

        [HttpGet("{projectId}")]
        public ActionResult<Project> GetProjectById(int projectId)
        {
            return Ok(serviceProject.GetProjectById(projectId));
        }
    }
}
