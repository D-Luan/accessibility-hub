using AccessibilityHub.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.Infrastructure.Data;

public class AccessibilityContext : DbContext
{
    public AccessibilityContext(DbContextOptions<AccessibilityContext> options)
        : base(options)
    {
    }
    
    public DbSet<Disability> Disabilities { get; set; }
    public DbSet<Resource> Resources { get; set; }
}
