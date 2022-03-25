using BusinessAccessLayer.services.tasks.DataModels;
using DataAccessLayer.Models;
using DataLayer.repos.task;

namespace BusinessAccessLayer.services.tasks
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepo<Tasks> _repository;

        public TasksService(ITasksRepo<Tasks> _repository)
        {
            this._repository = _repository;
        }

        public async Task<bool> CreateTask(Tasks task)
        {
            try
            {
                if (task == null)
                {
                    throw new Exception("task cant be null");
                }

                else
                {
                    return await _repository.Create(task);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Tasks> GetAllTasksByProject(int projectId)
        {
            try
            {
                return _repository.GetTasksByProject(projectId).ToList();
            } catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Tasks> GetTasksByProjectBySprint(int projectId, int sprintId)
        {
            try
            {
                if(projectId == 0 || sprintId == 0)
                {
                    throw new ArgumentNullException();
                }

                var allTasks = _repository.GetTasksByProject(projectId);
                List<Tasks> applyingTasks = new List<Tasks>();

                foreach(var task in allTasks)
                {
                    if(task.SprintId == sprintId)
                        applyingTasks.Add(task);
                }

                return applyingTasks;
            } catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<SprintView> GetTasksByProjectModeledToSprintData(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception();

                var tasks = _repository.GetTasksByProject(id).ToList();
                List<SprintView> sprintViewList = new List<SprintView>();

                foreach(var task in tasks)
                {
                    Item item = new Item(id: task.TaskId, start: task.TaskStartTime, end: task.TaskEndTime);
                    Group group = new Group(id: task.TaskId, content: task.TaskName);

                    SprintView sprintListItem = new SprintView(group: group, item: item);


                    sprintViewList.Add(sprintListItem);
                }

                return sprintViewList;
            } catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateTaskTag(int taskId, string taskTag)
        {
            try
            {
                if (taskId == 0)
                    return false;

                bool updated = await _repository.UpdateTaskTag(taskId, taskTag);

                return updated;
            } catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateTask(Tasks task)
        {
            try
            {
                if (task == null)
                    return false;

                bool updated = await _repository.UpdateTask(task);

                return updated;
            } catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            try
            {
                bool deleted = await _repository.DeleteTask(taskId);
                return deleted;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
