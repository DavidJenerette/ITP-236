using UserModelApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("AppSettings.json", optional: false)
    .Build();

var connectionString = config.GetConnectionString("UserRolesDb");

var optionsBuilder = new DbContextOptionsBuilder<UserContext>()
    .UseSqlServer(connectionString);

#if DEBUG
optionsBuilder
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging();
#endif

using var db = new UserContext(optionsBuilder.Options);

try
{
    Console.WriteLine("= CREATE =");
    CreateUserAndProject(db);

    Console.WriteLine("\n= UPDATE =");
    UpdateExistingProject(db);

    Console.WriteLine("\n= DELETE =");
    DeleteProjectObserveCascade(db);

    Console.WriteLine("\n= READ =");
    ReadProjectsNoTracking(db);

    Console.WriteLine("\n= TRACKING =");
    TrackingUpdateWorks(db);

    Console.WriteLine("\n= NO-TRACKING =");
    NoTrackingUpdateFails(db);

    Console.WriteLine("\n= FIX NO-TRACKING ERROR =");
    FixNoTrackingUpdate(db);

    Console.WriteLine("\n= QUERIES =");
    RunReportingQueries(db);
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected application error: {ex.Message}");
}

static void CreateUserAndProject(UserContext db)
{
    try
    {
        var user = new Users
        {
            Name = "Maria Lopez",
            Department = "Development"
        };

        var project = new Projects
        {
            ProjectName = "Help Desk Portal",
            Budget = 32000,
            WorkItems = new List<WorkItems>
            {
                new WorkItems { Title = "Design Database", IsCompleted = false },
                new WorkItems { Title = "Create API", IsCompleted = false }
            }
        };

        var userProject = new UserProjects
        {
            User = user,
            Project = project,
            AssignedOn = DateTime.Now,
            HoursPerWeek = 15
        };

        db.UserProjects.Add(userProject);
        db.SaveChanges();

        Console.WriteLine($"Added user {user.Name} and project: {project.ProjectName}");
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Create failed due to a database update error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Create failed: {ex.Message}");
    }
}

static void UpdateExistingProject(UserContext db)
{
    try
    {
        var project = db.Projects.FirstOrDefault(p => p.ProjectId == 1);

        if (project == null)
        {
            Console.WriteLine("Project not found.");
            return;
        }

        project.Budget += 500;
        db.SaveChanges();

        Console.WriteLine($"Updated project {project.ProjectName} budget to {project.Budget}");
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Update failed due to a database update error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Update failed: {ex.Message}");
    }
}

static void DeleteProjectObserveCascade(UserContext db)
{
    try
    {
        var project = db.Projects
            .Include(p => p.WorkItems)
            .Include(p => p.UserProjects)
            .FirstOrDefault(p => p.ProjectId == 2);

        if (project == null)
        {
            Console.WriteLine("Project not found.");
            return;
        }

        db.Projects.Remove(project);
        db.SaveChanges();

        Console.WriteLine($"Deleted project {project.ProjectName}. Related WorkItems and UserProjects were also deleted.");
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Delete failed due to a database update error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Delete failed: {ex.Message}");
    }
}

static void ReadProjectsNoTracking(UserContext db)
{
    var projects = db.Projects
        .AsNoTracking()
        .Include(p => p.WorkItems)
        .Include(p => p.UserProjects)
            .ThenInclude(up => up.User)
        .OrderBy(p => p.ProjectName)
        .ToList();

    foreach (var project in projects)
    {
        Console.WriteLine($"{project.ProjectName} | Budget: {project.Budget}");

        foreach (var item in project.WorkItems)
        {
            Console.WriteLine($"   Work Item: {item.Title} | Completed: {item.IsCompleted}");
        }

        foreach (var up in project.UserProjects)
        {
            Console.WriteLine($"   Assigned User: {up.User.Name} | Hours/Week: {up.HoursPerWeek}");
        }
    }
}

static void TrackingUpdateWorks(UserContext db)
{
    try
    {
        var user = db.Users.FirstOrDefault(u => u.UserId == 1);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        user.Department = "Architecture";
        db.SaveChanges();

        Console.WriteLine("Tracking update succeeded.");
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Tracking update failed due to a database update error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Tracking update failed: {ex.Message}");
    }
}

static void NoTrackingUpdateFails(UserContext db)
{
    var user = db.Users
        .AsNoTracking()
        .FirstOrDefault(u => u.UserId == 1);

    if (user == null)
    {
        Console.WriteLine("User not found.");
        return;
    }

    user.Department = "Security";
    db.SaveChanges();

    var refreshedUser = db.Users.First(u => u.UserId == 1);
    Console.WriteLine($"No-tracking update failed. Department is still: {refreshedUser.Department}");
}

static void FixNoTrackingUpdate(UserContext db)
{
    try
    {
        var user = db.Users
            .AsNoTracking()
            .FirstOrDefault(u => u.UserId == 1);

        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        user.Department = "Security";

        db.Entry(user).State = EntityState.Modified;
        db.SaveChanges();

        Console.WriteLine("Fixed no-tracking update using EntityState.Modified. This tells EF Core that something was changed even though it wasn't tracking it.");
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Fix failed due to a database update error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fix failed: {ex.Message}");
    }
}

static void RunReportingQueries(UserContext db)
{
    var query1 = db.Projects
        .Include(p => p.WorkItems)
        .OrderByDescending(p => p.Budget)
        .ToList();

    Console.WriteLine("\n1. Projects with WorkItems ordered by Budget:");
    foreach (var p in query1)
    {
        Console.WriteLine($"{p.ProjectName} - {p.Budget} - WorkItems: {p.WorkItems.Count}");
    }

    var query2 = db.Users
        .Include(u => u.UserProjects)
            .ThenInclude(up => up.Project)
        .OrderBy(u => u.Name)
        .ToList();

    Console.WriteLine("\n2. Users with assigned Projects:");
    foreach (var u in query2)
    {
        Console.WriteLine(u.Name);
        foreach (var up in u.UserProjects)
        {
            Console.WriteLine($"   {up.Project.ProjectName} ({up.HoursPerWeek} hrs/week)");
        }
    }

    var query3 = db.UserProjects
        .Include(up => up.User)
        .Include(up => up.Project)
        .GroupBy(up => up.User.Name)
        .Select(g => new
        {
            UserName = g.Key,
            TotalHours = g.Sum(x => x.HoursPerWeek)
        })
        .OrderByDescending(x => x.TotalHours)
        .ToList();

    Console.WriteLine("\n3. Total assigned hours per user:");
    foreach (var row in query3)
    {
        Console.WriteLine($"{row.UserName}: {row.TotalHours}");
    }

    var query4 = db.WorkItems
        .Include(w => w.Project)
        .Where(w => !w.IsCompleted)
        .OrderBy(w => w.Project.ProjectName)
        .ThenBy(w => w.Title)
        .ToList();

    Console.WriteLine("\n4. Incomplete work items by project:");
    foreach (var w in query4)
    {
        Console.WriteLine($"{w.Project.ProjectName} - {w.Title}");
    }

    var query5 = db.Projects
        .Include(p => p.UserProjects)
            .ThenInclude(up => up.User)
        .Where(p => p.UserProjects.Count >= 1)
        .OrderByDescending(p => p.UserProjects.Count)
        .Select(p => new
        {
            p.ProjectName,
            AssignedUsers = p.UserProjects.Count,
            p.Budget
        })
        .ToList();

    Console.WriteLine("\n5. Projects with assigned user counts:");
    foreach (var p in query5)
    {
        Console.WriteLine($"{p.ProjectName} - Users: {p.AssignedUsers} - Budget: {p.Budget}");
    }
}