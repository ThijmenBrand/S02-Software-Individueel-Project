using BusinessLayer.services.tasks.DataModels;
using DataAccessLayer.Models;

namespace BusinessLayer.services.tasks;

public interface IExcecuteTasksService
{
    Task<bool> ExcecuteCreateTask(Tasks task);
    Task<bool> ExcecuteUpdateTaskTag(int taskId, string taskTag);
    Task<bool> ExcecuteUpdateTask(Tasks task);
    Task<IEnumerable<SprintView>> ExcecuteGetTasksByProjectModeledToSprintData(int sprintId);
    Task<IEnumerable<Tasks>> ExcecuteGetTasksByProjectBySprint(int sprintId);
    void ExcecuteDeleteTask(int taskId);
    IEnumerable<Tasks> ExcecuteGetAllTasksByProject(int projectId);
    Task<Tasks> ExcecuteGetTaskById(int taskId);
}
