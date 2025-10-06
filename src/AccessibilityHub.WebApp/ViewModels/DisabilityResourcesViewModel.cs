using AccessibilityHub.WebApp.Dtos;

namespace AccessibilityHub.WebApp.ViewModels;

public class DisabilityResourcesViewModel
{
    public int DisabilityId { get; set; }
    public string DisabilityName { get; set; }
    public IEnumerable<ResourceDto> Resources { get; set; }
}
