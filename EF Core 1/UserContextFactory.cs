using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EF_Core_1
{
    public class UserContextFactory : IDesignTimeDbContextFactory<UserContext>
    {
        public UserContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: false)
                .Build();

            var connectionString = config.GetConnectionString("UserRolesDb");

            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new UserContext(optionsBuilder.Options);
        }
    }
}