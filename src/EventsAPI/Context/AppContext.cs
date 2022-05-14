using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Context;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options)
            : base(options)
    {
    }
}