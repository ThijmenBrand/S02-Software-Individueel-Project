using DataAccessLayer.Models;

namespace BusinessLayer.services.project;

public interface IServiceProject
{
    Task<bool> AddProject(Project project, int userId);
    void DeleteProject(int projectId);
    IEnumerable<Project> GetAllProjects(int userId);
    Task<Project> GetProjectById(int projectId);
}
