using DataAccessLayer.Models;
using DataLayer.repos.sprint;
using ValidatorMiddleware;

namespace BusinessLayer.services.sprint
{
    public class SprintService : ISprintService
    {
        private readonly IExcecuteSprintService _excecuteSprintService;
        private readonly IInputMiddleWare _inputMiddleware;
        public SprintService(IExcecuteSprintService excecuteSprintService, IInputMiddleWare _inputMiddleware)
        {
            _excecuteSprintService = excecuteSprintService;
            this._inputMiddleware = _inputMiddleware;
        }

        public Task<bool> AddSprint(Sprint sprint)
        {
          _inputMiddleware.ValidateNull(sprint);

            return _excecuteSprintService.ExcecuteAddSprint(sprint);
        }

        public IEnumerable<Sprint> GetAllSprintsByProject(int projectId)
        {
            _inputMiddleware.ValidateZero(projectId);

            return _excecuteSprintService.ExcecuteGetAllSprintsByProject(projectId);
        }

        public Sprint GetCurrentSprint(int projectId)
        {
            _inputMiddleware.ValidateZero(projectId);

            return _excecuteSprintService.ExcecuteGetCurrentSprint(projectId);
        }

        public Task<Sprint> GetSprintDetails(int sprintId)
        {
            _inputMiddleware.ValidateZero(sprintId);

            return _excecuteSprintService.ExcecuteGetSprintDetails(sprintId);
        }

        public Task<bool> UpdateSprint(Sprint sprint)
        {
            _inputMiddleware.ValidateNull(sprint);

            return _excecuteSprintService.ExcecuteUpdateSprint(sprint);
        }
    }
}
