using DataAccessLayer.Models;
using BusinessLayer.extensions;
using ValidatorMiddleware;

namespace BusinessLayer.services.project;

 public class ServiceProject : IServiceProject
 {
     private readonly IExcecuteServiceProject _projectExcecute;
    private readonly IInputMiddleWare _inputMiddleware;

     public ServiceProject(IExcecuteServiceProject _projectExcecute, IInputMiddleWare _inputMiddleware)
     {
         this._projectExcecute = _projectExcecute;
        this._inputMiddleware = _inputMiddleware;
     }

     public Task<Project> GetProjectById(int projectId)
     {
        _inputMiddleware.ValidateZero(projectId);

         return _projectExcecute.ExcecuteGetProjectById(projectId);
     }

     public Task<bool> AddProject(Project project, int userId)
     {
        _inputMiddleware.ValidateNull(project);
        _inputMiddleware.ProjectParameterValidator(project);
        _inputMiddleware.ValidateZero(userId);

         return _projectExcecute.ExcecuteAddProject(project, userId);
     }

     public async void DeleteProject(int projectId)
     {
        _inputMiddleware.ValidateZero(projectId);
         
         await _projectExcecute.ExcecuteDeleteProject(projectId);
     }
     public IEnumerable<Project> GetAllProjects(int userId) => _projectExcecute.ExcecuteGetAllProjects(userId);
 }
