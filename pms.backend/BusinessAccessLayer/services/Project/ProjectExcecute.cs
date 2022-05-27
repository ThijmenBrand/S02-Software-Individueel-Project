using DataAccessLayer.Models;
using DataLayer.repos.project;

namespace BusinessLayer.services.project;

public class ProjectExcecute : IExcecuteServiceProject
{
    private readonly IProjectRepo<Project> _repository;
    public ProjectExcecute(IProjectRepo<Project> _repository)
    {
        this._repository = _repository;
    }
    public async Task<Project> ExcecuteGetProjectById(int id) => await _repository.GetById(id);
    public async Task<bool> ExcecuteAddProject(Project project, int userId)
    {
        project.ProjectDate = DateTime.Now;
        return await _repository.Create(project, userId);
    }
    public async Task ExcecuteDeleteProject(int projectId) => await _repository.Delete(projectId);
    public IEnumerable<Project> ExcecuteGetAllProjects(int userId) => _repository.GetAll(userId).ToList();
}
