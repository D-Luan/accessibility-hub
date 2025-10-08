using System.ComponentModel.DataAnnotations;

namespace AccessibilityHub.WebApp.Dtos;

public class UpdateResourceDto
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    [Url]
    public string Url { get; set; } = string.Empty;

    [Required]
    public string Category { get; set; } = string.Empty;
}