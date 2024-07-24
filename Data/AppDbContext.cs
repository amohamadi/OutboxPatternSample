using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data;

// dotnet ef --startup-project ../OrderApi migrations add [MigrationName]  --context AppDbContext
// dotnet ef --startup-project ../OrderApi  database update --context AppDbContext
// dotnet ef --startup-project ../OrderApi migrations remove --context AppDbContext

// add-migration -context AppDbContext [MigrationName]
// update-database -context AppDbContext

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}