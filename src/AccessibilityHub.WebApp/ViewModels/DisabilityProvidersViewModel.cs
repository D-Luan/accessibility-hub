using AccessibilityHub.WebApp.Dtos;

namespace AccessibilityHub.WebApp.ViewModels;

public class DisabilityProvidersViewModel
{
    public int DisabilityId { get; set; }

    public required string DisabilityName { get; set; }

    public required IEnumerable<ProviderDto> Providers { get; set; }
}