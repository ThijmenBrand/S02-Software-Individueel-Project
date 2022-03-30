using DataAccessLayer.Models;

namespace BusinessAccessLayer.services
{
    public interface ISprintService
    {
        public Task<bool> AddSprint(Sprint sprint);
        public IEnumerable<Sprint> GetAllSprintsByProject(int projectId);
        public IEnumerable<Sprint> GetSprintDetails(int sprintId);
        public Task<bool> UpdateSprint(Sprint sprint);
    }
}
