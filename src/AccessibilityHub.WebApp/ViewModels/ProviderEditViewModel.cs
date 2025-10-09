using AccessibilityHub.WebApp.Dtos;

namespace AccessibilityHub.WebApp.ViewModels;

public class ProviderEditViewModel
{
    public int DisabilityId { get; set; }

    public required UpdateProviderDto Provider { get; set; }
}