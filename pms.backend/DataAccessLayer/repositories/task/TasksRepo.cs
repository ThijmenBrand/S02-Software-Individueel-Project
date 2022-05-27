using DataAccessLayer.data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.repos.task
{
    public class TasksRepo : ITasksRepo<Tasks>
    {
        private readonly DataContext _DataContext;

        public TasksRepo(DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public async Task<bool> Create(Tasks task, int? userId)
        {
            _DataContext.Add(task);
            await _DataContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Tasks>> GetTasksBySprint(int sprintId)
        {
            //return await _DataContext.task.Where(x => x.SprintId == sprintId).ToListAsync();

            return await _DataContext.task.FromSqlInterpolated($"SELECT * FROM dbo.task WHERE SprintId = {sprintId}").ToListAsync();
        }

        public async Task<bool> UpdateTaskTag(int taskId, string taskTag)
        {
            _DataContext.task.FromSqlInterpolated($"UPDATE dbo.task SET TaskTag = {taskTag} WHERE TaskId = {taskId}");
            await _DataContext.SaveChangesAsync();

            return true;
        }

        public async Task Update(Tasks updatedTask)
        {
            var task = await _DataContext.task.FindAsync(updatedTask.TaskId);
            task.TaskName = updatedTask.TaskName;
            task.TaskStartTime = updatedTask.TaskStartTime;
            task.TaskEndTime = updatedTask.TaskEndTime;
            task.TaskDescription = updatedTask.TaskDescription;
            task.TaskTag = updatedTask.TaskTag;
            task.TaskImportance = updatedTask.TaskImportance;
            task.TaskWorkLoad = updatedTask.TaskWorkLoad;

            await _DataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            _DataContext.task.FromSqlInterpolated($"DELETE FROM dbo.task WHERE TaskId = {id}");
            await _DataContext.SaveChangesAsync();
        }

        public IEnumerable<Tasks> GetAllTasks(int projectId)
        {
            var sprints = _DataContext.sprint.Where(t => t.ProjectId == projectId).ToList();
            List<Tasks> tasks = new List<Tasks>();

            foreach(Sprint sprint in sprints)
            {
                var tasksInSprint = _DataContext.task.Where(t => t.SprintId == sprint.SprintId);
                if(tasksInSprint.Count() > 1)
                {
                    foreach(Tasks task in tasksInSprint)
                    {
                        tasks.Add(task);
                    }
                } else if (tasksInSprint.Count() == 1)
                {
                    tasks.Add(tasksInSprint.FirstOrDefault());
                }
            }

            return tasks;
        }

        public async Task<Tasks> GetById(int taskId)
        {
            var user = await _DataContext.task.FromSqlInterpolated($"SELECT * FROM dbo.task WHERE TaskId = {taskId}").FirstOrDefaultAsync();
            if (user == null) throw new KeyNotFoundException("Task not found");
            return user;
        }
    }

}
