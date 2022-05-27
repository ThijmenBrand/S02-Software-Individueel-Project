using ExceptionMiddleware;
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

        public async Task<bool> Create(Project project, int? userId)
        {
            project.ProjectOwnerId = userId ?? default;
            _DataContext.Add(project);
            await _DataContext.SaveChangesAsync();

            return true;
        }
        public async Task Delete(int projectId)
        {
            //var project = _DataContext.project.Where(x => x.ProjectId == projectId).FirstOrDefault();
            //var obj = _DataContext.Remove(project);
            _DataContext.project.FromSqlInterpolated($"delete from dbo.project where ProjectId = {projectId}");
            await _DataContext.SaveChangesAsync();
        }
        public IEnumerable<Project> GetAll(int UserId)
        {
            var obj = _DataContext.project.FromSqlRaw($"select * from project where ProjectOwnerId = {UserId}").ToList(); //Where(p => p.ProjectOwnerId == UserId).ToList();
            if (obj != null) return obj;
            else return Enumerable.Empty<Project>();
        }
        public async Task<Project?> GetById(int id)
        {
            var obj = _DataContext.project.FirstOrDefault(x => x.ProjectId == id);
            if (obj != null) return obj;
            else return null;
        }
        public async Task Update(Project project)
        {
            var obj = _DataContext.Update(project);
            if (obj != null) await _DataContext.SaveChangesAsync();
        }
    }
}
