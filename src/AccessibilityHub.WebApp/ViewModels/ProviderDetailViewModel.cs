using AccessibilityHub.WebApp.Dtos;

namespace AccessibilityHub.WebApp.ViewModels;

public class ProviderDetailViewModel
{
    public int DisabilityId { get; set; }

    public required ProviderDto Provider { get; set; }
}