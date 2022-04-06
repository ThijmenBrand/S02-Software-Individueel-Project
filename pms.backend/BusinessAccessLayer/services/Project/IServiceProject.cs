using DataAccessLayer.Models;

namespace BusinessLayer.services.project
{
    public interface IServiceProject
    {
        Task<bool> AddProject(Project project);
        void DeleteProject(int id);
        void UpdateProject(int id);
        IEnumerable<Project> GetAllProjects();
    }
}
