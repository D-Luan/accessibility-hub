using System.ComponentModel.DataAnnotations;

namespace AccessibilityHub.WebApp.Dtos;

public class CreateDisabilityDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }
}
