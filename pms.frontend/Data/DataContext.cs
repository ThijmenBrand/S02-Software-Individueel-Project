using Microsoft.EntityFrameworkCore;
using pms.backend.Models;

namespace pms.backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ProjectsModel> projectsModel { get; set; }
    }
}
