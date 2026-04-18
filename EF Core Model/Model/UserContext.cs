#define Logging

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UserModelApp.Model
{
    public class UserContext : DbContext
    {
        private readonly ILoggerFactory? _loggerFactory;

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public UserContext(DbContextOptions<UserContext> options, ILoggerFactory loggerFactory)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        public DbSet<Users> Users => Set<Users>();
        public DbSet<Roles> Roles => Set<Roles>();
        public DbSet<Projects> Projects => Set<Projects>();
        public DbSet<UserProjects> UserProjects => Set<UserProjects>();
        public DbSet<WorkItems> WorkItems => Set<WorkItems>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if Logging
            if (_loggerFactory != null)
            {
                optionsBuilder.UseLoggerFactory(_loggerFactory);
                optionsBuilder.EnableSensitiveDataLogging();
            }
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("UserRoles_Updated");

            modelBuilder.Entity<Users>().HasKey(u => u.UserId);
            modelBuilder.Entity<Roles>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Projects>().HasKey(p => p.ProjectId);
            modelBuilder.Entity<WorkItems>().HasKey(w => w.WorkItemId);

            modelBuilder.Entity<Projects>()
                .Property(p => p.Budget)
                .HasPrecision(10, 2);

            modelBuilder.Entity<UserProjects>()
                .HasKey(up => new { up.UserId, up.ProjectId });

            modelBuilder.Entity<UserProjects>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserProjects)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserProjects>()
                .HasOne(up => up.Project)
                .WithMany(p => p.UserProjects)
                .HasForeignKey(up => up.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WorkItems>()
                .HasOne(w => w.Project)
                .WithMany(p => p.WorkItems)
                .HasForeignKey(w => w.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            SeedData.Seed(modelBuilder);
        }
    }
}