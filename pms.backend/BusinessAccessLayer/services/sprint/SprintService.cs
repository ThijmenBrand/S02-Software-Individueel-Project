using DataAccessLayer.Models;
using DataLayer.repos.sprint;

namespace BusinessAccessLayer.services
{
    public class SprintService : ISprintService
    {
        private readonly ISprintRepo<Sprint> _repository;

        public SprintService(ISprintRepo<Sprint> _repository)
        {
            this._repository = _repository;
        }

        public async Task<bool> AddSprint(Sprint sprint)
        {
            try
            {
                if(sprint == null)
                    throw new ArgumentNullException(nameof(sprint));

                var res = await _repository.Create(sprint);

                if (!res)
                    throw new Exception("Something went wrong while adding this sprint");
            
                return true;
                
            } catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Sprint> GetAllSprintsByProject(int ProjectId)
        {
            try
            {
                if(ProjectId == 0)
                    throw new ArgumentNullException(nameof(ProjectId));

                return _repository.GetAllByProject(ProjectId);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
