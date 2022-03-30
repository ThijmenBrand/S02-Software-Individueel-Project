using DataAccessLayer.Models;
using DataLayer.repos.sprint;
using BusinessLayer.helperClasses;

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
                    throw new Exception("Sprint cant be null!");

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
                    throw new Exception("ProjectId cant be null");

                return _repository.GetAllByProject(ProjectId);
            } catch (Exception)
            {
                return Enumerable.Empty<Sprint>();
            }
        }

        public IEnumerable<Sprint> GetSprintDetails(int sprintId)
        {
            if (sprintId == 0)
                throw new Exception("SprintId cant be null");

            return _repository.GetSprintDetails(sprintId);
        }

        public Task<bool> UpdateSprint(Sprint sprint)
        {
            if (sprint == null)
                throw new Exception("sprint cant be null");

            return _repository.UpdateSprintDetails(sprint);
        }
    }
}
