using System.ComponentModel.DataAnnotations;

namespace AccessibilityHub.WebApp.Dtos;

public class CreateResourceDto
{
    [Required(ErrorMessage = "The Name field is required.")]
    [StringLength(100, ErrorMessage = "The name cannot exceed 100 characters.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "The name cannot exceed 500 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "The URL field is required.")]
    [Url(ErrorMessage = "Please enter a valid URL.")]
    public string Url { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Category field is required.")]
    public string Category { get; set; } = string.Empty;

    [Required]
    public int DisabilityId { get; set; }
}
