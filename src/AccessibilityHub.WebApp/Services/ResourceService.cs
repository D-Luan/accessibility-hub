using AccessibilityHub.Entities.Models;
using AccessibilityHub.Infrastructure.Data;
using AccessibilityHub.WebApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Services;

public class ResourceService : IResourceService
{
    private readonly AccessibilityDbContext _context;

    public ResourceService(AccessibilityDbContext context)
    {
        _context = context;
    }

    public async Task<List<ResourceDto>> GetAllResourcesAsync()
    {
        var resourceDto = await _context.Resources
            .Select(r => new ResourceDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Url = r.Url,
                Category = r.Category,
            })
            .ToListAsync();

        return resourceDto;
    }

    public async Task<List<ResourceDto>> GetDisabilityResourcesByIdAsync(int disabilityId)
    {
        var resourceDto = await _context.Resources
            .Where(r => r.DisabilityId == disabilityId)
            .Select(r => new ResourceDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Url = r.Url,
                Category = r.Category,
            })
            .ToListAsync();

        return resourceDto;
    }

    public async Task<ResourceDto?> GetResourceByIdAsync(int id)
    {
        var resourceDto = await _context.Resources
            .Where(r => r.Id == id)
            .Select(r => new ResourceDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Url = r.Url,
                Category = r.Category,
            })
            .SingleOrDefaultAsync();

        return resourceDto;
    }

    public async Task<ResourceDto> CreateResourceAsync(CreateResourceDto createDto)
    {
        var resourceEntity = new Resource
        {
            Name = createDto.Name,
            Description = createDto.Description ?? string.Empty,
            Url = createDto.Url,
            Category = createDto.Category,
            DisabilityId = createDto.DisabilityId,
        };

        _context.Resources.Add(resourceEntity);
        await _context.SaveChangesAsync();

        var resultDto = new ResourceDto
        {
            Id = resourceEntity.Id,
            Name = resourceEntity.Name,
            Description = resourceEntity.Description,
            Url = resourceEntity.Url,
            Category = resourceEntity.Category,
        };

        return resultDto;
    }

    public async Task<UpdateResourceDto?> GetResourceForUpdateAsync(int id)
    {
        var resource = await _context.Resources.FindAsync(id);
        if (resource == null)
        {
            return null;
        }

        return new UpdateResourceDto
        {
            Id = resource.Id,
            Name = resource.Name,
            Description = resource.Description,
            Url = resource.Url,
            Category = resource.Category,
        };
    }

    public async Task<bool> UpdateResourceAsync(int id, UpdateResourceDto updateDto)
    {
        var resourceEntity = await _context.Resources.FindAsync(id);

        if (resourceEntity == null)
        {
            return false;
        }

        resourceEntity.Name = updateDto.Name;
        resourceEntity.Description = updateDto.Description ?? string.Empty;
        resourceEntity.Url = updateDto.Url;
        resourceEntity.Category = updateDto.Category;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ResourceExists(id))
            {
                return false;
            }
            else
            {
                throw;
            }
        }

        return true;
    }

    public async Task<bool> DeleteResourceAsync(int id)
    {
        var resource = await _context.Resources.FindAsync(id);

        if (resource == null)
        {
            return false;
        }

        _context.Resources.Remove(resource);
        await _context.SaveChangesAsync();
        return true;
    }

    private bool ResourceExists(int id)
    {
        return _context.Resources.Any(e => e.Id == id);
    }
}