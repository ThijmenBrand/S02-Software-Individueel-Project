using DataAccessLayer.contracts;
using DataAccessLayer.Models;
using DataAccessLayer.repositories;

namespace BusinessAccessLayer.services
{
    public class ServiceProject : IServiceProject
    {
        private readonly IRepository<Project> _repository;
        
        public ServiceProject(IRepository<Project> _repository)
        {
            this._repository = _repository;
        }

        public async Task<Project> AddProject(Project project)
        {
            try
            {
                if (project == null)
                {
                    throw new ArgumentNullException(nameof(project));
                } else
                {
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
