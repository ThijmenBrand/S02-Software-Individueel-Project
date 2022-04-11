using DataAccessLayer.Models;

namespace BusinessLayer.services.sprint
{
    public interface ISprintService
    {
        public Task<bool> AddSprint(Sprint sprint);
        public IEnumerable<Sprint> GetAllSprintsByProject(int projectId);
        public Sprint GetCurrentSprint(int projectId);
        public IEnumerable<Sprint> GetSprintDetails(int sprintId);
        public Task<bool> UpdateSprint(Sprint sprint);
    }
}
