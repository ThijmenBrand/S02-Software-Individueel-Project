using BusinessAccessLayer.services.tasks;
using BusinessAccessLayer.services.tasks.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace pms.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        [HttpPost]
        public async Task<ActionResult<List<Tasks>>> AddTask(Tasks task)
        {
            await _tasksService.CreateTask(task);
            return Ok(_tasksService.GetTasksByProjectBySprint(task.ProjectId, task.SprintId));
        }

        [HttpGet("{projectId}")]
        public ActionResult<List<Tasks>> GetTasksByProject(int projectId)
        {
            var res = _tasksService.GetAllTasksByProject(projectId).ToList();
            return Ok(res);
            //var res = _tasksService.GetTasksByProjectModeledToSprintData(projectId).ToList();
            //return Ok(res);
        }

        [HttpGet("Sprint/{sprintId}/{projectId}/")]
        public ActionResult<List<Tasks>> GetTasksBySprint(int projectId, int sprintId)
        {
            var res = _tasksService.GetTasksByProjectBySprint(projectId, sprintId).ToList();
            return Ok(res);
        }

        [HttpPut("{taskId}")]
        public async Task<ActionResult<bool>> UpdateTaskTag(int taskId, [FromBody] string taskTag)
        {
            bool res = await _tasksService.UpdateTaskTag(taskId, taskTag);
            return res ? Ok() : BadRequest();
        }
    }
}
