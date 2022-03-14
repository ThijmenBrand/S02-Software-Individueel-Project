using DataAccessLayer.Models;
using DataLayer.repos.project;
using BusinessAccessLayer.extensions;
using Microsoft.AspNetCore.Mvc;

namespace BusinessAccessLayer.services
{
    public class ServiceProject : IServiceProject
    {
        private readonly IProjectRepo<Project> _repository;
        private readonly ProjectValidator _validator = new ProjectValidator();
        
        public ServiceProject(IProjectRepo<Project> _repository)
        {
            this._repository = _repository;
        }

        public async Task<bool> AddProject(Project project)
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
                    return await _repository.Create(project);
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
                    var obj = _repository.GetAll().Where(x => x.ProjectId == id).FirstOrDefault();
                    _repository.Delete(obj);
                }
            } catch(Exception)
            {
                throw;
            }
        }
        public void UpdateProject(int id)
        {
            try
            {
                if (id != 0)
                {
                    var obj = _repository.GetAll().Where(x => x.ProjectId == id).FirstOrDefault();
                    if (obj != null) _repository.Update(obj);
                }
            } catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Project> GetAllProjects()
        {
            try
            {
                return _repository.GetAll().ToList();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
