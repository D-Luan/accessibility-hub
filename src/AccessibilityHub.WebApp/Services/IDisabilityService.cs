using AccessibilityHub.Entities.Models;
using AccessibilityHub.Infrastructure.Data;
using AccessibilityHub.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Services;

public interface IDisabilityService
{
    Task<List<DisabilityDto>> GetAllDisabilitiesAsync();
    Task<DisabilityDto?> GetDisabilityByIdAsync(int id);
    public class DisabilityService : IDisabilityService
    {
        private readonly AccessibilityDbContext _context;

        public DisabilityService(AccessibilityDbContext context)
        {
            _context = context;
        }

        public async Task<List<DisabilityDto>> GetAllDisabilitiesAsync()
        {
            var disabilityDto = await _context.Disabilities
                .Select(d => new DisabilityDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description
                })
                .ToListAsync();

            return disabilityDto;
        }

        public async Task<DisabilityDto?> GetDisabilityByIdAsync(int id)
        {
            var disabilityDto = await _context.Disabilities
                .Where(d => d.Id == id)
                .Select(d => new DisabilityDto
                {
                    Name = d.Name,
                    Id = d.Id,
                    Description = d.Description
                })
                .SingleOrDefaultAsync();

            return disabilityDto;
        }
    }
}
