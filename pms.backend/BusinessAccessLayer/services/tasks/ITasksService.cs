using DataAccessLayer.Models;
using BusinessLayer.services.tasks.DataModels;

namespace BusinessLayer.services.tasks
{
    public interface ITasksService
    {
        Task<bool> CreateTask(Tasks task);
        Task<bool> UpdateTaskTag(int id, string taskTag);
        Task<bool> UpdateTask(Tasks tasks);
        IEnumerable<SprintView> GetTasksByProjectModeledToSprintData(int id);
        IEnumerable<Tasks> GetTasksByProjectBySprint(int sprintid);
        Task<bool> DeleteTask(int id);

    }
}
