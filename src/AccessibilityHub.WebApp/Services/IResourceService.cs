using AccessibilityHub.Entities.Models;
using AccessibilityHub.Infrastructure.Data;
using AccessibilityHub.WebApp.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Services;

public interface IResourceService
{
    Task<List<ResourceDto>> GetAllResourcesAsync();
    Task<ResourceDto?> GetResourceByIdAsync(int id);
    Task<ResourceDto> CreateResourceAsync(CreateResourceDto createDto);

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
                    Category = r.Category
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
                    Category = r.Category
                })
                .SingleOrDefaultAsync();

            return resourceDto;
        }

        public async Task<ResourceDto> CreateResourceAsync(CreateResourceDto createDto)
        {
            var resourceEntity = new Resource
            {
                Name = createDto.Name,
                Description = createDto.Description,
                Url = createDto.Url,
                Category = createDto.Category,
                DisabilityId = createDto.DisabilityId
            };

            _context.Resources.Add(resourceEntity);
            await _context.SaveChangesAsync();

            var resultDto = new ResourceDto
            {
                Id = resourceEntity.Id,
                Name = resourceEntity.Name,
                Description = resourceEntity.Description,
                Url = resourceEntity.Url,
                Category = resourceEntity.Category
            };

            return resultDto;
        }
    }
}
