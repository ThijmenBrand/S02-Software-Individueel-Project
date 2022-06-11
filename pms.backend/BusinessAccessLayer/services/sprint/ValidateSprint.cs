using DataAccessLayer.Models;
using Ardalis.GuardClauses;

namespace BusinessLayer.services.sprint
{
    public class ValidateSprint : IValidateSprint
    {
        private readonly IExcecuteSprintService _excecuteSprintService;
        public ValidateSprint(IExcecuteSprintService excecuteSprintService)
        {
            _excecuteSprintService = excecuteSprintService;
        }

        public Task<bool> AddSprint(Sprint sprint)
        {
            Guard.Against.Null<Sprint>(sprint, nameof(sprint));

            return _excecuteSprintService.ExcecuteAddSprint(sprint);
        }

        public IEnumerable<Sprint> GetAllSprintsByProject(int projectId)
        {
            Guard.Against.NegativeOrZero(projectId, nameof(projectId));

            return _excecuteSprintService.ExcecuteGetAllSprintsByProject(projectId);
        }

        public Sprint GetCurrentSprint(int projectId)
        {
            Guard.Against.NegativeOrZero(projectId, nameof(projectId));

            return _excecuteSprintService.ExcecuteGetCurrentSprint(projectId);
        }

        public Task<Sprint> GetSprintDetails(int sprintId)
        {
            Guard.Against.NegativeOrZero(sprintId, nameof(sprintId));

            return _excecuteSprintService.ExcecuteGetSprintDetails(sprintId);
        }

        public Task<bool> UpdateSprint(Sprint sprint)
        {
            Guard.Against.Null<Sprint>(sprint, nameof(sprint));

            return _excecuteSprintService.ExcecuteUpdateSprint(sprint);
        }
    }
}
