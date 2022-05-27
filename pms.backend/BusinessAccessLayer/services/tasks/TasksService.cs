using BusinessLayer.extensions;
using BusinessLayer.services.tasks.DataModels;
using DataAccessLayer.Models;
using DataLayer.repos.task;
using ValidatorMiddleware;

namespace BusinessLayer.services.tasks
{
    public class TasksService : ITasksService
    {
        private readonly IExcecuteTasksService _excecuteTasksService;
        private readonly IInputMiddleWare _inputMiddleware;

        public TasksService(IExcecuteTasksService excecuteTasksService, IInputMiddleWare inputMiddleware)
        {
            _excecuteTasksService = excecuteTasksService;
            _inputMiddleware = inputMiddleware;
        }

        public Task<bool> CreateTask(Tasks task)
        {
            _inputMiddleware.ValidateNull(task);
            return _excecuteTasksService.ExcecuteCreateTask(task);
        }

        public Task<IEnumerable<Tasks>> GetTasksByProjectBySprint(int sprintId)
        {
            _inputMiddleware.ValidateZero(sprintId);
            return _excecuteTasksService.ExcecuteGetTasksByProjectBySprint(sprintId);
        }

        public Task<IEnumerable<SprintView>> GetTasksByProjectModeledToSprintData(int sprintId)
        {
            _inputMiddleware.ValidateZero(sprintId);
            return _excecuteTasksService.ExcecuteGetTasksByProjectModeledToSprintData(sprintId);
        }

        public Task<bool> UpdateTaskTag(int taskId, string taskTag)
        {
            _inputMiddleware.ValidateZero(taskId);
            return _excecuteTasksService.ExcecuteUpdateTaskTag(taskId, taskTag);
        }

        public Task<bool> UpdateTask(Tasks task)
        {
            _inputMiddleware.ValidateNull(task);
            return _excecuteTasksService.ExcecuteUpdateTask(task);
        }

        public void DeleteTask(int taskId)
        {
            _inputMiddleware.ValidateZero(taskId);
            _excecuteTasksService.ExcecuteDeleteTask(taskId);
        }

        public IEnumerable<Tasks> GetAllTasksByProject(int projectId)
        {
            _inputMiddleware.ValidateZero(projectId);
            return _excecuteTasksService.ExcecuteGetAllTasksByProject(projectId);
        }

        public Task<Tasks> GetTaskById(int taskId)
        {
            _inputMiddleware.ValidateZero(taskId);
            return _excecuteTasksService.ExcecuteGetTaskById(taskId);
        }
    }
}
