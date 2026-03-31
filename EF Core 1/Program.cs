using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EF_Core_1;

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("AppSettings.json", optional: false)
    .Build();

var connectionString = config.GetConnectionString("UserRolesDb");

var options = new DbContextOptionsBuilder<UserContext>()
    .UseSqlServer(connectionString)
    .Options;

using var db = new UserContext(options);

var users = db.Users
    .Include(u => u.Roles)
    .ToList();

foreach (var user in users)
{
    Console.WriteLine($"{user.Name}:");
    foreach (var role in user.Roles)
        Console.WriteLine($"   - {role.RoleName}");
}
