using AccessibilityHub.Entities.Models;
using AccessibilityHub.Infrastructure.Data;
using AccessibilityHub.WebApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Services;

public class ProviderService : IProviderService
{
    private readonly AccessibilityDbContext _context;

    public ProviderService(AccessibilityDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProviderDto>> GetAllProvidersAsync()
    {
        var providerDto = await _context.Providers
            .Select(r => new ProviderDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Url = r.Url,
                Category = r.Category,
            })
            .ToListAsync();

        return providerDto;
    }

    public async Task<List<ProviderDto>> GetDisabilityProvidersByIdAsync(int disabilityId)
    {
        var providerDto = await _context.Providers
            .Where(r => r.DisabilityId == disabilityId)
            .Select(r => new ProviderDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Url = r.Url,
                Category = r.Category,
            })
            .ToListAsync();

        return providerDto;
    }

    public async Task<ProviderDto?> GetProviderByIdAsync(int id)
    {
        var providerDto = await _context.Providers
            .Where(r => r.Id == id)
            .Select(r => new ProviderDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Url = r.Url,
                Category = r.Category,
            })
            .SingleOrDefaultAsync();

        return providerDto;
    }

    public async Task<ProviderDto> CreateProviderAsync(CreateProviderDto createDto)
    {
        var providerEntity = new Provider
        {
            Name = createDto.Name,
            Description = createDto.Description ?? string.Empty,
            Url = createDto.Url,
            Category = createDto.Category,
            DisabilityId = createDto.DisabilityId,
        };

        _context.Providers.Add(providerEntity);
        await _context.SaveChangesAsync();

        var resultDto = new ProviderDto
        {
            Id = providerEntity.Id,
            Name = providerEntity.Name,
            Description = providerEntity.Description,
            Url = providerEntity.Url,
            Category = providerEntity.Category,
        };

        return resultDto;
    }

    public async Task<UpdateProviderDto?> GetProviderForUpdateAsync(int id)
    {
        var provider = await _context.Providers.FindAsync(id);
        if (provider == null)
        {
            return null;
        }

        return new UpdateProviderDto
        {
            Id = provider.Id,
            Name = provider.Name,
            Description = provider.Description,
            Url = provider.Url,
            Category = provider.Category,
        };
    }

    public async Task<bool> UpdateProviderAsync(int id, UpdateProviderDto updateDto)
    {
        var providerEntity = await _context.Providers.FindAsync(id);

        if (providerEntity == null)
        {
            return false;
        }

        providerEntity.Name = updateDto.Name;
        providerEntity.Description = updateDto.Description ?? string.Empty;
        providerEntity.Url = updateDto.Url;
        providerEntity.Category = updateDto.Category;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProviderExists(id))
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

    public async Task<bool> DeleteProviderAsync(int id)
    {
        var provider = await _context.Providers.FindAsync(id);

        if (provider == null)
        {
            return false;
        }

        _context.Providers.Remove(provider);
        await _context.SaveChangesAsync();
        return true;
    }

    private bool ProviderExists(int id)
    {
        return _context.Providers.Any(e => e.Id == id);
    }
}