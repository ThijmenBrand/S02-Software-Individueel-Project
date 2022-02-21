using DataAccessLayer.contracts;
using DataAccessLayer.data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.repositories
{
    public class TasksRepo : ITasksRepo<Tasks>
    {
        private readonly DataContext _DataContext;

        public TasksRepo(DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public async Task<bool> Create(Tasks task)
        {
            try { 

                if (task != null)
                {
                    _DataContext.Add(task);
                    await _DataContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    throw new ArgumentNullException("The input is not a valid project");
                }

            } catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Tasks> GetAll()
        {
            try
            {
                return _DataContext.task.ToList();
            } catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Tasks> GetTasksByProject(int id)
        {
            try
            {
                return _DataContext.task
                    .Where(t => t.ProjectId == id)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
