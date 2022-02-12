using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pms.backend.Models;

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
        public async Task<ActionResult<List<TasksModel>>> GetTasks()
        {
            return Ok(await _context.tasksModel.ToListAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<List<TasksModel>> GetTask(int id)
        {
            var Task = _context.tasksModel.FromSqlRaw($"SELECT * FROM TasksModel WHERE ProjectId = {id}").ToList();

            return Ok(Task);
        }
    }
}
