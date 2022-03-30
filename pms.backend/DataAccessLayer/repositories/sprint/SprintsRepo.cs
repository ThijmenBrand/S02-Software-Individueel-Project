using DataAccessLayer.Models;
using DataAccessLayer.data;

namespace DataLayer.repos.sprint
{
    public class SprintsRepo : ISprintRepo<Sprint>
    {
        private readonly DataContext _DataContext;

        public SprintsRepo(DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public async Task<bool> Create(Sprint sprint)
        {
            try
            {
                if(sprint != null)
                {
                    _DataContext.Add(sprint);
                    await _DataContext.SaveChangesAsync();

                    return true;
                } else
                {
                    throw new ArgumentNullException();
                }
            } catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Sprint> GetAllByProject(int projectId)
        {
            try
            {
                if (projectId != 0)
                {
                    return _DataContext.sprint
                        .Where(s => s.ProjectId == projectId)
                        .ToList();
                } else
                {
                    throw new ArgumentNullException();
                }
            } catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateSprintDetails(Sprint updateSprint)
        {
            if (updateSprint == null)
                throw new Exception("sprint cant be null");

            var sprint = await _DataContext.sprint.FindAsync(updateSprint.SprintId);

            if (sprint == null)
                throw new Exception("No sprint found");

            sprint.SprintStart = updateSprint.SprintStart;
            sprint.SprintEnd = updateSprint.SprintEnd;
            sprint.SprintName = updateSprint.SprintName;

            await _DataContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<Sprint> GetSprintDetails(int sprintId)
        {
            return _DataContext.sprint
                  .Where(s => s.SprintId == sprintId)
                  .ToList();
        }


    }
}
