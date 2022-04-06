using BusinessLayer.services.sprint;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using System;

namespace ApiLayer.Controllers
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

        
        [HttpGet("currentSprint/{projectId}")]
        public ActionResult<Sprint> GetCurrentSprint(int projectId)
        {
            DateTime today = DateTime.Today;

            var allSprints = _sprintService.GetAllSprintsByProject(projectId);
            foreach(Sprint sprint in allSprints)
            {
                DateTime sprintStart = sprint.SprintStart;
                DateTime sprintEnd = sprint.SprintEnd;

                if(today >= sprintStart && today <= sprintEnd)
                {
                    return Ok(sprint);
                }
            }


            Sprint noSprint = new Sprint();
            noSprint.SprintId = 666666666;
            return Ok(noSprint);
        }

        [HttpGet("currentSprint/Details/{sprintId}")]
        public ActionResult<Sprint> GetSprintDetails(int sprintId)
        {
            var res = _sprintService.GetSprintDetails(sprintId);
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
