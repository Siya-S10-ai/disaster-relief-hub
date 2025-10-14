using GiftOfGivers.Client.GiftOfGivers_Client.Pages;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace GiftOfGivers.Client.AzureSQL
{
    public class AzureDbContext : DbContext
    {
        public AzureDbContext(DbContextOptions<AzureDbContext> options) : base(options)
        {
            
        }

        // Add your DbSets here as you define your entities
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Reporters> Reporters { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Donation> Donations { get; set; }
        
        public DbSet<IncidentReport> IncidentReports { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Fallback connection string if not configured via DI
                optionsBuilder.UseSqlServer("my-connection-string-here");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure my entity relationships and constraints here
            // Table names matches my schema
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Reporter>().ToTable("Reporter");
            modelBuilder.Entity<Volunteer>().ToTable("Volunteer");
            modelBuilder.Entity<Donation>().ToTable("Donation");
            modelBuilder.Entity<IncidentReport>().ToTable("IncidentReport");
            modelBuilder.Entity<TaskEntity>().ToTable("Task");

            // Primary Keys
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<Admin>().HasKey(a => a.AdminId);
            modelBuilder.Entity<Reporter>().HasKey(r => r.ReporterId);
            modelBuilder.Entity<Volunteer>().HasKey(v => v.VolunteerId);
            modelBuilder.Entity<Donation>().HasKey(d => d.DonationId);
            modelBuilder.Entity<IncidentReport>().HasKey(i => i.ReportId);
            modelBuilder.Entity<TaskEntity>().HasKey(t => t.TaskId);

            // Relationships
            modelBuilder.Entity<Reporter>()
        .HasOne<User>()
        .WithMany()
        .HasForeignKey(r => r.UserId)
        .HasConstraintName("FK_Reporter_User");

    modelBuilder.Entity<Volunteer>()
        .HasOne<User>()
        .WithMany()
        .HasForeignKey(v => v.UserId)
        .HasConstraintName("FK_Volunteer_User");

    modelBuilder.Entity<Donation>()
        .HasOne<User>()
        .WithMany()
        .HasForeignKey(d => d.UserId)
        .HasConstraintName("FK_Donation_User");

    modelBuilder.Entity<IncidentReport>()
        .HasOne<Reporter>()
        .WithMany()
        .HasForeignKey(i => i.ReporterId)
        .HasConstraintName("FK_IncidentReport_Reporter");

    modelBuilder.Entity<TaskEntity>()
        .HasOne<Volunteer>()
        .WithMany()
        .HasForeignKey(t => t.VolunteerId)
        .HasConstraintName("FK_Task_Volunteer");
        }
    }

    public interface IAzureService
    {
        Task<bool> TestConnectionAsync();
        Task<T?> GetByIdAsync<T>(int id) where T : class;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
        Task<T> CreateAsync<T>(T entity) where T : class;
        Task<T> UpdateAsync<T>(T entity) where T : class;
        Task<bool> DeleteAsync<T>(int id) where T : class;
    }

    public class AzureService : IAzureService
    {
        private readonly AzureDbContext _context;
        private readonly ILogger<AzureService> _logger;

        public AzureService(AzureDbContext context, ILogger<AzureService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                await _context.Database.CanConnectAsync();
                _logger.LogInformation("Successfully connected to Azure SQL Database");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to connect to Azure SQL Database");
                return false;
            }
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting {EntityType} with ID {Id}", typeof(T).Name, id);
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all {EntityType}", typeof(T).Name);
                return Enumerable.Empty<T>();
            }
        }

        public async Task<T> CreateAsync<T>(T entity) where T : class
        {
            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Created new {EntityType}", typeof(T).Name);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating {EntityType}", typeof(T).Name);
                throw;
            }
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Updated {EntityType}", typeof(T).Name);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating {EntityType}", typeof(T).Name);
                throw;
            }
        }

        public async Task<bool> DeleteAsync<T>(int id) where T : class
        {
            try
            {
                var entity = await GetByIdAsync<T>(id);
                if (entity != null)
                {
                    _context.Set<T>().Remove(entity);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Deleted {EntityType} with ID {Id}", typeof(T).Name, id);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting {EntityType} with ID {Id}", typeof(T).Name, id);
                return false;
            }
        }
    }
}