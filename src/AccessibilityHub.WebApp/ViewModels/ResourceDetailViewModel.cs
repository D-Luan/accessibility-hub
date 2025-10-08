using AccessibilityHub.WebApp.Dtos;

namespace AccessibilityHub.WebApp.ViewModels;

public class ResourceDetailViewModel
{
    public int DisabilityId { get; set; }

    public required ResourceDto Resource { get; set; }
}