using DataAccessLayer.Models;
using BusinessLayer.services.tasks.DataModels;

namespace BusinessLayer.services.tasks
{
    public interface ITasksService
    {
        Task<bool> CreateTask(Tasks task);
        Task<bool> UpdateTaskTag(int id, string taskTag);
        Task<bool> UpdateTask(Tasks tasks);
        Task<IEnumerable<SprintView>> GetTasksByProjectModeledToSprintData(int id);
        Task<IEnumerable<Tasks>> GetTasksByProjectBySprint(int sprintid);
        bool DeleteTask(int id);
        IEnumerable<Tasks> GetAllTasksByProject(int projectId);
        Task<Tasks> GetTaskById(int id);
    }
}
