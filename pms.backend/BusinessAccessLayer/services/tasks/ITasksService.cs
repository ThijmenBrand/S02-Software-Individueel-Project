using DataAccessLayer.Models;
using BusinessLayer.services.tasks.DataModels;

namespace BusinessLayer.services.tasks
{
    public interface ITasksService
    {
        Task<bool> CreateTask(Tasks task);
        Task<bool> UpdateTaskTag(int taskId, string taskTag);
        Task<bool> UpdateTask(Tasks task);
        Task<IEnumerable<SprintView>> GetTasksByProjectModeledToSprintData(int sprintId);
        Task<IEnumerable<Tasks>> GetTasksByProjectBySprint(int sprintId);
        void DeleteTask(int taskId);
        IEnumerable<Tasks> GetAllTasksByProject(int projectId);
        Task<Tasks> GetTaskById(int taskId);
    }
}
