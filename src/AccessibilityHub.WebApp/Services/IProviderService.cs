using AccessibilityHub.WebApp.Dtos;

namespace AccessibilityHub.WebApp.Services;

public interface IProviderService
{
    Task<List<ProviderDto>> GetAllProvidersAsync();

    Task<List<ProviderDto>> GetDisabilityProvidersByIdAsync(int disabilityId);

    Task<ProviderDto?> GetProviderByIdAsync(int id);

    Task<ProviderDto> CreateProviderAsync(CreateProviderDto createDto);

    Task<UpdateProviderDto?> GetProviderForUpdateAsync(int id);

    Task<bool> UpdateProviderAsync(int id, UpdateProviderDto providerDto);

    Task<bool> DeleteProviderAsync(int id);
}