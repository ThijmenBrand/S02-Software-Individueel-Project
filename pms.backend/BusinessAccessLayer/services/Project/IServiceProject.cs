using DataAccessLayer.Models;

namespace BusinessLayer.services.project
{
    public interface IServiceProject
    {
        Task<bool> AddProject(Project project, int UserId);
        void DeleteProject(int id);
        IEnumerable<Project> GetAllProjects(int UserId);
        Task<Project> GetProjectById(int id);
    }
}
