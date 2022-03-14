using DataLayer.repos.project;
using DataAccessLayer.Models;
using DataAccessLayer.data;

namespace DataLayer.repos.project
{
    public class RepositoryProject : IProjectRepo<Project>
    {
        private readonly DataContext _DataContext;

        public RepositoryProject(DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public async Task<bool> Create(Project project)
        {
            try
            {
                if (project != null)
                {
                    project.Tasks = null;
                    _DataContext.Add(project);
                    await _DataContext.SaveChangesAsync();

                    return true;
                } else
                {
                    throw new ArgumentNullException("The input is not a valid project");
                }
            } catch (Exception)
            {
                throw;
            }
        }
        public void Delete(Project project)
        {
            try
            {
                if (project != null)
                {
                    var obj = _DataContext.Remove(project);
                    if (obj != null)
                    {
                        _DataContext.SaveChangesAsync();
                    }
                }
            } catch(Exception)
            {
                throw;
            }
        }
        public IEnumerable<Project> GetAll()
        {
            try
            {
                var obj = _DataContext.project.ToList();
                if (obj != null) return obj;
                else return null;
            } catch (Exception)
            {
                throw;
            }
        }
        public Project? GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    var obj = _DataContext.project.FirstOrDefault(x => x.ProjectId == id);
                    if (obj != null) return obj;
                    else return null;
                } else
                {
                    return null;
                }
            } catch (Exception)
            {
                throw;
            }
        }
        public void Update(Project project)
        {
            try
            {
                if (project != null)
                {
                    var obj = _DataContext.Update(project);
                    if (obj != null) _DataContext.SaveChangesAsync();
                }
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
