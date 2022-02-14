using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pms.backend.Models.Tasks;
using System.Linq;

namespace pms.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly DataContext _context;

        public TasksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<TasksModel>>> GetAllTasks()
        {
            return Ok(await _context.tasksModel.ToListAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<List<TasksModel>> GetTaskById(int id)
        {
            var task = _context.tasksModel.FromSqlRaw($"SELECT * FROM TasksModel WHERE TaskId = {id}").ToList();

            if(task == null)
            {
                return NotFound("No task with the given Id was found");
            }

            return Ok(task);
        }

        [HttpGet("ProjectTask/{id}")]
        public ActionResult<List<TasksModel>> GetTaskByProjectId(int id)
        {
            var task = _context.tasksModel.FromSqlRaw($"SELECT * FROM TasksModel WHERE ProjectId = {id}").ToList();

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var task = _context.tasksModel.Find(id);
            if(task == null)
            {
                return NotFound();
            }

            _context.tasksModel.Remove(task);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
       public async Task<ActionResult<List<ITasksModel>>> UpdateTask([FromBody] ITasksModel updateData, int id)
        {
            var task = await _context.tasksModel.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            task.TaskName = updateData.TaskName;
            task.TaskDescription = updateData.TaskDescription;
            task.TaskTag = updateData.TaskTag;
            task.TaskStartTime = updateData.TaskStartTime;
            task.TaskEndTime = updateData.TaskEndTime;


            await _context.SaveChangesAsync();

            return Ok(task);
        }
    }
}