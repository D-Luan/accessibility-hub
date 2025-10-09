using AccessibilityHub.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> builder)
    {
        builder.HasData(
            new Provider { Id = 1, Name = "Sonova", Description = "...", Url = "https://www.sonova.com/en", Category = "Holding Company", DisabilityId = 1 }
        );
    }
}
