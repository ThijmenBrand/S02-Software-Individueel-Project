using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessAccessLayer.services
{
    public interface IServiceProject
    {
        Task AddProject(Project project);
        void DeleteProject(int id);
        void UpdateProject(int id);
        IEnumerable<Project> GetAllProjects();
    }
}
