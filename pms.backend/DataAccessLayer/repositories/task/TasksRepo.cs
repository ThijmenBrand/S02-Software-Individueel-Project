using DataAccessLayer.data;
using DataAccessLayer.Models;

namespace DataLayer.repos.task
{
    public class TasksRepo : ITasksRepo<Tasks>
    {
        private readonly DataContext _DataContext;

        public TasksRepo(DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public async Task<bool> Create(Tasks task)
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

        public IEnumerable<Tasks> GetTasksByProject(int id)
        {
            try
            {
                return _DataContext.task
                    .Where(t => t.ProjectId == id)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateTaskTag(int taskId, string taskTag)
        {
            try
            {
                var task = await _DataContext.task.FindAsync(taskId);
                if(task == null)
                {
                    return false;
                }

                task.TaskTag = taskTag;

                await _DataContext.SaveChangesAsync();

                return true;
            } catch(Exception)
            {
                throw;
            }
        }
    }

}
