using DataLayer.repos.project;
using DataAccessLayer.Models;
using DataAccessLayer.data;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.repos.project
{
    public class RepositoryProject : IProjectRepo<Project>
    {
        private readonly DataContext _DataContext;

        public RepositoryProject(DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public async Task<bool> Create(Project project, int UserId)
        {
            try
            {
                if (project != null)
                {
                    project.ProjectOwnerId = UserId;
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
        public void Delete(int projectId)
        {
            try
            {
                if (projectId != 0)
                {
                    //var project = _DataContext.project.Where(x => x.ProjectId == projectId).FirstOrDefault();
                    //var obj = _DataContext.Remove(project);
                    _DataContext.project.FromSqlRaw($"delete from project where ProjectId = {projectId}");
                    _DataContext.SaveChangesAsync();
                }
            } catch(Exception)
            {
                throw;
            }
        }
        public IEnumerable<Project> GetAll(int UserId)
        {
            try
            {
                var obj = _DataContext.project.FromSqlRaw($"select * from project where ProjectOwnerId = {UserId}").ToList(); //Where(p => p.ProjectOwnerId == UserId).ToList();
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
                    if (obj != null) return (Project?)obj;
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
