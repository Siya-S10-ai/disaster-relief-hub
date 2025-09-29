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

        // Add additional DbSets later:
        // public DbSet<IncidentReport> IncidentReports { get; set; }
        // public DbSet<Donation> Donations { get; set; }
    }
}
