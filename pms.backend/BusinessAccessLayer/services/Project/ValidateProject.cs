using DataAccessLayer.Models;
using BusinessLayer.extensions;
using Ardalis.GuardClauses;

namespace BusinessLayer.services.project;

 public class ValidateProject : IValidateProject
 {
     private readonly IExcecuteProject _projectExcecute;

     public ValidateProject(IExcecuteProject _projectExcecute)
     {
         this._projectExcecute = _projectExcecute;
     }

     public Task<Project> GetProjectById(int projectId)
     {
        Guard.Against.NegativeOrZero(projectId, nameof(projectId));

         return _projectExcecute.ExcecuteGetProjectById(projectId);
     }

     public Task<bool> AddProject(Project project, int userId)
     {
        Guard.Against.Null(project, nameof(project));
        Guard.Against.ProjectParams(project, nameof(project));
        Guard.Against.NegativeOrZero(userId, nameof(userId));

         return _projectExcecute.ExcecuteAddProject(project, userId);
     }

     public async Task DeleteProject(int projectId)
     {
        Guard.Against.NegativeOrZero(projectId, nameof(projectId));
         
         await _projectExcecute.ExcecuteDeleteProject(projectId);
     }
     public IEnumerable<Project> GetAllProjects(int userId) => _projectExcecute.ExcecuteGetAllProjects(userId);
 }
