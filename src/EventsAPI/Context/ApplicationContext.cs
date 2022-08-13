using EventsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
    {
    }

    /// <summary>
    /// Supporting default and global controls for Audit events (dates and edits)
    /// TODO: user info needs to be added!
    /// </summary>
    /// <returns></returns>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.DateCreated = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "Unknown";
                    break;
                case EntityState.Modified:
                    entry.Entity.DateLastModified = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = "Unknown";
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasMany(c => c.Attendees)
            .WithOne(e => e.AttendedEvent);
    }
}