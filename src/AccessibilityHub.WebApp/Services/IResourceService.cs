using AccessibilityHub.WebApp.Dtos;

namespace AccessibilityHub.WebApp.Services;

public interface IResourceService
{
    Task<List<ResourceDto>> GetAllResourcesAsync();

    Task<List<ResourceDto>> GetDisabilityResourcesByIdAsync(int disabilityId);

    Task<ResourceDto?> GetResourceByIdAsync(int id);

    Task<ResourceDto> CreateResourceAsync(CreateResourceDto createDto);

    Task<UpdateResourceDto?> GetResourceForUpdateAsync(int id);

    Task<bool> UpdateResourceAsync(int id, UpdateResourceDto resourceDto);

    Task<bool> DeleteResourceAsync(int id);
}