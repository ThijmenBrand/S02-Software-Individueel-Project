using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;

namespace DataAccessLayer.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                .HasOne<Project>(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(s => s.ProjectId);
        }

        public DbSet<Project> project { get; set; }
        public DbSet<Tasks> task { get; set; }
    }
}
