using AccessibilityHub.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.Infrastructure.Data;

public class AccessibilityDbContext : DbContext
{
    public AccessibilityDbContext(DbContextOptions<AccessibilityDbContext> options)
        : base(options)
    {
    }

    public DbSet<Disability> Disabilities { get; set; }
    public DbSet<Resource> Resources { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccessibilityDbContext).Assembly);
    }
}
