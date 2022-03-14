using BusinessAccessLayer.services;
using Microsoft.AspNetCore.Mvc;

namespace pms.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintsController : ControllerBase
    {
        private readonly ISprintService _sprintService;

        public SprintsController(ISprintService sprintService)
        {
            _sprintService = sprintService;
        }

        [HttpPost]
        public async Task<ActionResult<List<Sprint>>> AddSprint(Sprint sprint)
        {
            await _sprintService.AddSprint(sprint);
            return Ok(_sprintService.GetAllSprintsByProject(sprint.ProjectId));
        }

        [HttpGet("{projectId}")]
        public ActionResult<List<Sprint>> GetSprintsByProject(int projectId)
        {
            var res = _sprintService.GetAllSprintsByProject(projectId);
            return Ok(res);
        }

    }
}
