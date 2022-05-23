using BusinessLayer.extensions;
using BusinessLayer.services.tasks.DataModels;
using DataAccessLayer.Models;
using DataLayer.repos.task;

namespace BusinessLayer.services.tasks
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepo<Tasks> _repository;
        private readonly TaskPlanAlgorigm _algo;

        public TasksService(ITasksRepo<Tasks> _repository)
        {
            this._repository = _repository;
            _algo = new TaskPlanAlgorigm();
        }

        public async Task<bool> CreateTask(Tasks task)
        {
            try
            {
                if (task == null)
                    throw new Exception("task cant be null");

                else
                {
                    return await _repository.Create(task, null);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Tasks>> GetTasksByProjectBySprint(int SprintId)
        {
            try
            {
                if (SprintId == 0)
                    throw new Exception("sprintId cant be null");

                List<Tasks> tasks = await _repository.GetTasksBySprint(SprintId);

                return tasks;

            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<SprintView>> GetTasksByProjectModeledToSprintData(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception();

                var tasks = await _repository.GetTasksBySprint(id);
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

                await _repository.Update(task);

                return true;
            } catch(Exception)
            {
                throw;
            }
        }

        public bool DeleteTask(int taskId)
        {
            try
            {
                _repository.Delete(taskId);
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Tasks> GetAllTasksByProject(int projectId)
        {
            if (projectId == 0)
                throw new Exception("project id cant be 0");

            var tasks = _repository.GetAllTasks(projectId).ToList();
            var plannedTasks = new List<Tasks>();

            foreach (var task in tasks)
            {
                if (!(task.TaskStartTime < Convert.ToDateTime("2000-01-01 00:00:00.0000000")))
                {
                    plannedTasks.Add(task);
                }
            }

            return plannedTasks;
        }

        public async Task<Tasks> GetTaskById(int id)
        {
            if(id == 0)
                throw new Exception("task id cant be 0");

            var task = await _repository.GetById(id);
            
            return task;
        }
    }
}
