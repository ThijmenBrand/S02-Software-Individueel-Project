using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.services
{
    public interface IServiceProject
    {
        Task<Project> AddProject(Project project);
        void DeleteProject(int id);
        void UpdateProject(int id);
        IEnumerable<Project> GetAllProjects();
    }
}
