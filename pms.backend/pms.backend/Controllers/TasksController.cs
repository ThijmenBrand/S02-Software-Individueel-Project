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
        public ActionResult<List<Tasks>> GetTasksBySprint(int sprintId, int projectId)
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

        [HttpPut("update")]
        public async Task<ActionResult<bool>> UpdateTask([FromBody] Tasks task)
        {
            task.TaskStartTime = task.TaskStartTime.ToLocalTime();
            task.TaskEndTime = task.TaskEndTime.ToLocalTime();

            bool res = await _tasksService.UpdateTask(task);

            return res ? Ok() : BadRequest();
        }

        [HttpDelete("{taskId}/{sprintId}/{projectId}")]
        public async Task<ActionResult<Tasks>> DeleteTask(int taskId, int sprintId, int projectId)
        {
            var res = await _tasksService.DeleteTask(taskId);
            return res ? Ok(_tasksService.GetTasksByProjectBySprint(projectId, sprintId)) : BadRequest();
        }
    }
}
