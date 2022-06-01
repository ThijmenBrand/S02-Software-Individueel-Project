using DataAccessLayer.Models;
using BusinessLayer.extensions;
using Ardalis.GuardClauses;

namespace BusinessLayer.services.project;

 public class ServiceProject : IServiceProject
 {
     private readonly IExcecuteServiceProject _projectExcecute;

     public ServiceProject(IExcecuteServiceProject _projectExcecute)
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
        Guard.Against.Null<Project>(project, nameof(project));
        Guard.Against.NegativeOrZero(userId, nameof(userId));

         return _projectExcecute.ExcecuteAddProject(project, userId);
     }

     public async void DeleteProject(int projectId)
     {
        Guard.Against.NegativeOrZero(projectId, nameof(projectId));
         
         await _projectExcecute.ExcecuteDeleteProject(projectId);
     }
     public IEnumerable<Project> GetAllProjects(int userId) => _projectExcecute.ExcecuteGetAllProjects(userId);
 }
