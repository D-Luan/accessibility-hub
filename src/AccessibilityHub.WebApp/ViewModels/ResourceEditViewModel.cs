using AccessibilityHub.WebApp.Dtos;

namespace AccessibilityHub.WebApp.ViewModels;

public class ResourceEditViewModel
{
    public int DisabilityId { get; set; }

    public required UpdateResourceDto Resource { get; set; }
}