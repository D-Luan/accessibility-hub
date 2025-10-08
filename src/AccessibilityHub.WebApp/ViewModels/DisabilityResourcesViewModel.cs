using AccessibilityHub.WebApp.Dtos;

namespace AccessibilityHub.WebApp.ViewModels;

public class DisabilityResourcesViewModel
{
    public int DisabilityId { get; set; }

    public required string DisabilityName { get; set; }

    public required IEnumerable<ResourceDto> Resources { get; set; }
}