using Cal.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cal.Api.Persistence;

public class CalDbContext : DbContext
{
    public DbSet<Activity> Activities => Set<Activity>();
    
    public CalDbContext(DbContextOptions<CalDbContext> options)
         : base(options) { }

    protected override void OnModelCreating(
        ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(
            new ActivityConfig());
    }
}
