using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GiftOfGivers.Server.Models;

namespace GiftOfGivers.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // Add additional DbSets:
        public DbSet<Report> Reports { get; set; }
        public DbSet<VolunteerTask> VolunteerTasks { get; set; }
    }
}

