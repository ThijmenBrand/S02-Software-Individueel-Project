using Microsoft.EntityFrameworkCore;
using pms.backend.Models.Projects;
using pms.backend.Models.Tasks;

namespace pms.backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ProjectsModel> projectsModel { get; set; }
        public DbSet<TasksModel> tasksModel { get; set; }
    }
}
