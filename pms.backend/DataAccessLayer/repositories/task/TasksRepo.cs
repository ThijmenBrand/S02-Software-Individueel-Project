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
            try { 

                if (task != null)
                {
                    _DataContext.Add(task);
                    await _DataContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new ArgumentNullException("The input is not a valid project");
                }

            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Tasks>> GetTasksBySprint(int sprintId)
        {
            if (sprintId == 0)
                throw new Exception("sprintId cant be null");

            return await _DataContext.task.FromSqlInterpolated($"SELECT * FROM dbo.task WHERE SprintId = {sprintId}").ToListAsync();
        }

        public async Task<bool> UpdateTaskTag(int taskId, string taskTag)
        {
            try
            {
                _DataContext.task.FromSqlInterpolated($"UPDATE dbo.task SET TaskTag = {taskTag} WHERE TaskId = {taskId}");
                await _DataContext.SaveChangesAsync();

                return true;
            } catch(Exception)
            {
                throw;
            }
        }

        public async Task Update(Tasks updatedTask)
        {
            try
            {
                if (updatedTask == null)
                    throw new Exception("updated task cant be null");

                _DataContext.task.FromSqlInterpolated($"UPDATE dbo.task SET TaskName = {updatedTask.TaskName}, TaskDescription = {updatedTask.TaskDescription}, TaskTag = {updatedTask.TaskTag}, TaskStartTime = {updatedTask.TaskStartTime}, TaskEndTime = {updatedTask.TaskEndTime}, SprintId = {updatedTask.SprintId}, TaskImportance = {updatedTask.TaskImportance}, TaskWorkLoad = {updatedTask.TaskWorkLoad} WHERE TaskId = {updatedTask.TaskId}");
                await _DataContext.SaveChangesAsync();

            } catch (Exception)
            {
                throw;
            }
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
