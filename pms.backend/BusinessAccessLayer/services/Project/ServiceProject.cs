using DataAccessLayer.Models;
using DataLayer.repos.project;
using BusinessLayer.extensions;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.services.project
{
    public class ServiceProject : IServiceProject
    {
        private readonly IProjectRepo<Project> _repository;
        private readonly ProjectValidator _validator = new ProjectValidator();
        
        public ServiceProject(IProjectRepo<Project> _repository)
        {
            this._repository = _repository;
        }

        public Project GetProjectById(int projectId)
        {
            if (projectId == 0)
                throw new Exception("ProjectId cant be 0");

            var project = _repository.GetById(projectId);
            if (project == null)
                throw new Exception("Project could not be found");

            return project;
        }

        public async Task<bool> AddProject(Project project, int UserId)
        {
            try
            {
                if(project == null)
                {
                    throw new Exception("Project cant be null");
                }

                if (!_validator.ProjectParameterValidator(project))
                {
                    throw new Exception("One or more project parameters are invalid");
                } else
                {
                    project.ProjectDate = DateTime.Now;
                    return await _repository.Create(project, UserId);
                }
            } catch (Exception)
            {
                throw;
            }
        }
        public void DeleteProject(int id)
        {
            try
            {
                if(id != 0)
                {
                    _repository.Delete(id);
                } else
                {
                    throw new ArgumentNullException();
                }
            } catch(Exception)
            {
                throw;
            }
        }
        public IEnumerable<Project> GetAllProjects(int UserId)
        {
            try
            {
                return _repository.GetAll(UserId).ToList();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
