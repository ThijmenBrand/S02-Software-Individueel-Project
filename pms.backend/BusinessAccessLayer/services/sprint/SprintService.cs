using DataAccessLayer.Models;
using DataLayer.repos.sprint;

namespace BusinessLayer.services.sprint
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
                if(ProjectId == 0)
                    throw new Exception("ProjectId cant be null");

                var sprints = _repository.GetAllByProject(ProjectId);
                
                if(sprints == null)
                   return Enumerable.Empty<Sprint>();

            return sprints;
        }

        public Sprint GetCurrentSprint(int ProjectId)
        {
            if(ProjectId == 0)
            {
                throw new Exception("ProjectId  cant be null");
            }

            var allSprints = _repository.GetAllByProject(ProjectId);
            DateTime today = DateTime.Today;

            foreach (Sprint sprint in allSprints)
            {
                DateTime sprintStart = sprint.SprintStart;
                DateTime sprintEnd = sprint.SprintEnd;

                if (today >= sprintStart && today <= sprintEnd)
                {
                    return sprint;
                }
            }

            Sprint closestSprint = new Sprint();
            closestSprint = allSprints.LastOrDefault();
            foreach (Sprint sprint in allSprints)
            {
                if (sprint.SprintStart > today && sprint.SprintStart < closestSprint.SprintStart)
                {
                    closestSprint = sprint;
                }
            }

            return closestSprint;
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
