using System.ComponentModel.DataAnnotations;

namespace AccessibilityHub.WebApp.Dtos;

public class UpdateDisabilityDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }
}
