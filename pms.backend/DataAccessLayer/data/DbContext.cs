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
        public DbSet<Asset> asset { get; set; }
        public DbSet<Link> link { get; set; }
        public DbSet<Sprint> sprint { get; set; }
        public DbSet<Time> time { get; set; }
        public DbSet<User> user { get; set; }


    }
}
