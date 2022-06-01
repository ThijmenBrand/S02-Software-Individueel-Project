using BusinessLayer.services.tasks.DataModels;
using DataAccessLayer.Models;
using Ardalis.GuardClauses;

namespace BusinessLayer.services.tasks
{
    public class TasksService : ITasksService
    {
        private readonly IExcecuteTasksService _excecuteTasksService;

        public TasksService(IExcecuteTasksService excecuteTasksService)
        {
            _excecuteTasksService = excecuteTasksService;
        }

        public Task<bool> CreateTask(Tasks task)
        {
            Guard.Against.Null<Tasks>(task, nameof(task));
            return _excecuteTasksService.ExcecuteCreateTask(task);
        }

        public Task<IEnumerable<Tasks>> GetTasksByProjectBySprint(int sprintId)
        {
            Guard.Against.NegativeOrZero(sprintId, nameof(sprintId));
            return _excecuteTasksService.ExcecuteGetTasksByProjectBySprint(sprintId);
        }

        public Task<IEnumerable<SprintView>> GetTasksByProjectModeledToSprintData(int sprintId)
        {
            Guard.Against.NegativeOrZero(sprintId, nameof(sprintId));
            return _excecuteTasksService.ExcecuteGetTasksByProjectModeledToSprintData(sprintId);
        }

        public Task<bool> UpdateTaskTag(int taskId, string taskTag)
        {
            Guard.Against.NullOrEmpty(taskTag, nameof(taskTag));
            Guard.Against.NegativeOrZero(taskId, nameof(taskId));
            return _excecuteTasksService.ExcecuteUpdateTaskTag(taskId, taskTag);
        }

        public Task<bool> UpdateTask(Tasks task)
        {
            Guard.Against.Null<Tasks>(task, nameof(task));
            return _excecuteTasksService.ExcecuteUpdateTask(task);
        }

        public void DeleteTask(int taskId)
        {
            Guard.Against.NegativeOrZero(taskId, nameof(taskId));
            _excecuteTasksService.ExcecuteDeleteTask(taskId);
        }

        public IEnumerable<Tasks> GetAllTasksByProject(int projectId)
        {
            Guard.Against.NegativeOrZero(projectId, nameof(projectId));
            return _excecuteTasksService.ExcecuteGetAllTasksByProject(projectId);
        }

        public Task<Tasks> GetTaskById(int taskId)
        {
            Guard.Against.NegativeOrZero(taskId, nameof(taskId));
            return _excecuteTasksService.ExcecuteGetTaskById(taskId);
        }
    }
}
