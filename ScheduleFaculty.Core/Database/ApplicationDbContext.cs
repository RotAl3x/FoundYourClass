using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScheduleFaculty.Core.Entities;

namespace ScheduleFaculty.Core.Database;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<DatesToHour> DatesToHours { get; set; }
    public DbSet<Hour> Hour { get; set; }
    public DbSet<Location> Location { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}