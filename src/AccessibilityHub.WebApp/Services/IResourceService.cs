using AccessibilityHub.Entities.Models;
using AccessibilityHub.Infrastructure.Data;
using AccessibilityHub.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Services;

public interface IResourceService
{
    Task<List<ResourceDto>> GetAllResourcesAsync();
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

    }
}
