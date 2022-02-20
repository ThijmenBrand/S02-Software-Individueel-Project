using DataAccessLayer.contracts;
using DataAccessLayer.Models;
using DataAccessLayer.repositories;
using BusinessAccessLayer.extensions;
using Microsoft.AspNetCore.Mvc;

namespace BusinessAccessLayer.services
{
    public class ServiceProject : IServiceProject
    {
        private readonly IRepository<Project> _repository;
        private readonly ProjectValidator _validator = new ProjectValidator();
        
        public ServiceProject(IRepository<Project> _repository)
        {
            this._repository = _repository;
        }

        public async Task AddProject(Project project)
        {
            try
            {
                if (!_validator.ProjectParameterValidator(project))
                    throw new ArgumentException();

                if (project == null)
                {
                    throw new ArgumentNullException();
                } else
                {
                    project.ProjectDate = DateTime.Now;
                    await _repository.Create(project);
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
