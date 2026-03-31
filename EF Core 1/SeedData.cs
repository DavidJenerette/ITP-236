using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_1
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(
                new Users { UserId = 1, Name = "Daniel Gray" },
                new Users { UserId = 2, Name = "Neil Jones" }
            );

            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, RoleName = "Head Programmer" },
                new Roles { RoleId = 2, RoleName = "Debugger" }
            );

            modelBuilder.Entity<Users>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsersRoles",
                    j => j.HasData(
                        new { UsersUserId = 1, RolesRoleId = 1 },
                        new { UsersUserId = 2, RolesRoleId = 2 }
                    )
                );
        }
    }
}
