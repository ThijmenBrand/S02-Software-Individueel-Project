using BusinessLayer.services.tasks;
using BusinessLayer.services.tasks.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Authorize]
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
            return Ok(await _tasksService.GetTasksByProjectBySprint(task.SprintId));
        }

        [HttpGet("Sprint/{sprintId}/{projectId}/")]
        public async Task<ActionResult<List<Tasks>>> GetTasksBySprint(int sprintId)
        {
            var res = await _tasksService.GetTasksByProjectBySprint(sprintId);
            return Ok(res);
        }

        [HttpPut("{taskId}")]
        public async Task<ActionResult<bool>> UpdateTaskTag(int taskId, [FromBody] string taskTag)
        {
            bool res = await _tasksService.UpdateTaskTag(taskId, taskTag);
            return res ? Ok() : BadRequest();
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateTask([FromBody] Tasks task)
        {
            task.TaskStartTime = task.TaskStartTime.ToLocalTime();
            task.TaskEndTime = task.TaskEndTime.ToLocalTime();

            bool res = await _tasksService.UpdateTask(task);

            return res ? Ok() : BadRequest();
        }

        [HttpDelete("{taskId}/{sprintId}/{projectId}")]
        public async Task<ActionResult<Tasks>> DeleteTask(int taskId, int sprintId)
        {
            var res = _tasksService.DeleteTask(taskId);
            return res ? Ok(await _tasksService.GetTasksByProjectBySprint(sprintId)) : BadRequest();
        }

        [HttpGet("{projectId}")]
        public ActionResult<List<Tasks>> GetAllTasksByProject(int projectId)
        {
            return Ok(_tasksService.GetAllTasksByProject(projectId));
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<Tasks>> GetTaskById(int id)
        {
            return Ok(await _tasksService.GetTaskById(id));
        }
    }
}
