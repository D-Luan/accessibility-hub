using AccessibilityHub.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.HasData(
            new Resource { Id = 1, Name = "Sonova", Description = "...", Url = "https://www.sonova.com/en", Category = "Holding Company", DisabilityId = 1 }
        );
    }
}
