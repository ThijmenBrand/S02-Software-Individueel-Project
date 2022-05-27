using DataAccessLayer.Models;
using DataAccessLayer.data;
using Microsoft.EntityFrameworkCore;
using ExceptionMiddleware;

namespace DataLayer.repos.sprint
{
    public class SprintsRepo : ISprintRepo<Sprint>
    {
        private readonly DataContext _DataContext;

        public SprintsRepo(DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public async Task<bool> Create(Sprint sprint, int? userId)
        {
            _DataContext.Add(sprint);
            await _DataContext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<Sprint> GetAllByProject(int projectId)
        {
            return _DataContext.sprint
                .Where(s => s.ProjectId == projectId)
                .ToList();
        }

        public async Task Update(Sprint updateSprint)
        {
            var sprint = await _DataContext.sprint.FindAsync(updateSprint.SprintId);

            if (sprint == null)
                throw new ResourceNotFoundException("No sprint found");

            sprint.SprintStart = updateSprint.SprintStart;
            sprint.SprintEnd = updateSprint.SprintEnd;
            sprint.SprintName = updateSprint.SprintName;

            await _DataContext.SaveChangesAsync();
        }

        public async Task<Sprint> GetById(int sprintId)
        {
            var sprint = await _DataContext.sprint.FromSqlInterpolated($"SELECT * FROM dbo.sprint WHERE SprintId = {sprintId}").FirstOrDefaultAsync();
            if (sprint == null)
                throw new ResourceNotFoundException("Sprint not found!");
            return sprint;
        }

        public async Task Delete(int sprintId)
        {
            _DataContext.sprint.FromSqlRaw($"delete from dbo.sprint where SprintId = {sprintId}");
            await _DataContext.SaveChangesAsync();
        }
    }
}
