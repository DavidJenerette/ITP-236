using Microsoft.EntityFrameworkCore;

namespace UserModelApp.Model
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users { UserId = 1, Name = "Daniel Gray", Department = "Engineering" },
                new Users { UserId = 2, Name = "Neil Jones", Department = "QA" }
            );

            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, RoleName = "Head Programmer" },
                new Roles { RoleId = 2, RoleName = "Debugger" }
            );

            modelBuilder.Entity<Projects>().HasData(
                new Projects { ProjectId = 1, ProjectName = "Inventory System", Budget = 2500 },
                new Projects { ProjectId = 2, ProjectName = "Bug Tracker", Budget = 1800 }
            );

            modelBuilder.Entity<WorkItems>().HasData(
                new WorkItems { WorkItemId = 1, Title = "Build Login", IsCompleted = false, ProjectId = 1 },
                new WorkItems { WorkItemId = 2, Title = "Fix Search Bug", IsCompleted = false, ProjectId = 2 }
            );

            modelBuilder.Entity<UserProjects>().HasData(
                new UserProjects { UserId = 1, ProjectId = 1, AssignedOn = new DateTime(2026, 1, 10), HoursPerWeek = 20 },
                new UserProjects { UserId = 2, ProjectId = 2, AssignedOn = new DateTime(2026, 1, 15), HoursPerWeek = 15 }
            );

            modelBuilder.Entity<Users>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersRoles",
                    j => j.ToTable("UsersRoles", "UserRoles_Updated")
                          .HasData(
                              new { UsersUserId = 1, RolesRoleId = 1 },
                              new { UsersUserId = 2, RolesRoleId = 2 }
                          )
                );
        }
    }
}