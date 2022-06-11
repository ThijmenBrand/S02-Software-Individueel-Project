using DataAccessLayer.Models;

namespace BusinessLayer.services.project;

public interface IValidateProject
{
    Task<bool> AddProject(Project project, int userId);
    Task DeleteProject(int projectId);
    IEnumerable<Project> GetAllProjects(int userId);
    Task<Project> GetProjectById(int projectId);
}
