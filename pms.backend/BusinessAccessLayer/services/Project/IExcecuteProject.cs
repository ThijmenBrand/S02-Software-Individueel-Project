using DataAccessLayer.Models;

namespace BusinessLayer.services.project;

public interface IExcecuteProject
{
    Task<Project> ExcecuteGetProjectById(int id);
    Task<bool> ExcecuteAddProject(Project project, int userId);
    Task ExcecuteDeleteProject(int projectId);
    IEnumerable<Project> ExcecuteGetAllProjects(int userId);
}
