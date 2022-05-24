using BusinessLayer.services.sprint;
using Microsoft.AspNetCore.Mvc;
using ApiLayer.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace ApiLayer.Controllers
{
    [Authorize]
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

        
        [HttpGet("currentSprint/{projectId}")]
        public ActionResult<Sprint> GetCurrentSprint(int projectId)
        {
            return Ok(_sprintService.GetCurrentSprint(projectId));
        }

        [HttpGet("currentSprint/Details/{sprintId}")]
        public async Task<ActionResult<Sprint>> GetSprintDetails(int sprintId)
        {
            var res = await _sprintService.GetSprintDetails(sprintId);
            return Ok(res);
        }


        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateTask([FromBody] Sprint sprint)
        {
            sprint.SprintStart = sprint.SprintStart.AddHours(-2);
            sprint.SprintEnd = sprint.SprintEnd.AddHours(-2);

            bool res = await _sprintService.UpdateSprint(sprint);

            return res ? Ok() : BadRequest();
        }

    }
}
