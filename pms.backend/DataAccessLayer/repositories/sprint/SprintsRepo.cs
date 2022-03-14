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




    }
}
