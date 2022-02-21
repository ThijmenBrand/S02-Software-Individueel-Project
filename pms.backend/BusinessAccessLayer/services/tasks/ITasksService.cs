using DataAccessLayer.Models;
using BusinessAccessLayer.services.tasks.DataModels;

namespace BusinessAccessLayer.services.tasks
{
    public interface ITasksService
    {
        Task<bool> CreateTask(Tasks task);
        IEnumerable<Tasks> GetAllTasks();
        IEnumerable<SprintView> GetTasksByProjectModeledToSprintData(int id);

    }
}
