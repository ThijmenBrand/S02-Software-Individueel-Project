using DataAccessLayer.Models;

namespace BusinessLayer.services.sprint;

public interface IExcecuteSprintService
{
    Task<bool> ExcecuteAddSprint(Sprint sprint);
    public IEnumerable<Sprint> ExcecuteGetAllSprintsByProject(int projectId);
    public Sprint ExcecuteGetCurrentSprint(int projectId);
    public Task<Sprint> ExcecuteGetSprintDetails(int sprintId);
    public Task<bool> ExcecuteUpdateSprint(Sprint sprint);
}
