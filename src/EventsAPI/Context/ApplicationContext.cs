using EventsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
    {
    }
}