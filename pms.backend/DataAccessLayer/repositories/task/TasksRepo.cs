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

        public IEnumerable<Tasks> GetTasksBySprint(int sprintId)
        {
            if (sprintId == 0)
                throw new Exception("sprintId cant be null");

            return _DataContext.task.Where(t => t.SprintId == sprintId).ToList();
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

        public async Task<bool> UpdateTask(Tasks updatedTask)
        {
            try
            {
                if (updatedTask == null)
                    return false;

                var task = await _DataContext.task.FindAsync(updatedTask.TaskId);
                task.TaskName = updatedTask.TaskName;
                task.TaskStartTime = updatedTask.TaskStartTime;
                task.TaskEndTime = updatedTask.TaskEndTime;
                task.TaskDescription = updatedTask.TaskDescription;
                task.TaskTag = updatedTask.TaskTag;
                task.TaskImportance = updatedTask.TaskImportance;
                task.TaskWorkLoad = updatedTask.TaskWorkLoad;

                await _DataContext.SaveChangesAsync();

                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            try
            {
                var task = await _DataContext.task.FindAsync(taskId);

                _DataContext.Remove(task);
                await _DataContext.SaveChangesAsync();

                return true;
            } catch (Exception)
            {
                throw;   
            }
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

        public Tasks GetTaskById(int id)
        {
            var task = _DataContext.task.Where(t => t.TaskId == id).FirstOrDefault();
            if (task == null)
                throw new Exception("no task found");

            return task;
        }
    }

}
