using DataAccessLayer.Models;
using BusinessAccessLayer.services.tasks.DataModels;

namespace BusinessAccessLayer.services.tasks
{
    public interface ITasksService
    {
        Task<bool> CreateTask(Tasks task);
        Task<bool> UpdateTaskTag(int id, string taskTag);
        IEnumerable<Tasks> GetAllTasksByProject(int id);
        IEnumerable<SprintView> GetTasksByProjectModeledToSprintData(int id);

    }
}
