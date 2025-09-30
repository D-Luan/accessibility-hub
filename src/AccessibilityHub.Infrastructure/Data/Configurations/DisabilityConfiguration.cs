using AccessibilityHub.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DisabilityConfiguration : IEntityTypeConfiguration<Disability>
{
    public void Configure(EntityTypeBuilder<Disability> builder)
    {
        builder.HasData(
            new Disability { Id = 1, Name = "Auditiva", Description = "..." },
            new Disability { Id = 2, Name = "Visual", Description = "..." }
        );
    }
}
