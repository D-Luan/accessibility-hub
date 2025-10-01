using AccessibilityHub.Entities.Models;
using AccessibilityHub.Infrastructure.Data;
using AccessibilityHub.WebApp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Services;

public interface IDisabilityService
{
    Task<List<DisabilityDto>> GetAllDisabilitiesAsync();
    public class DisabilityService : IDisabilityService
    {
        private readonly AccessibilityDbContext _context;

        public DisabilityService(AccessibilityDbContext context)
        {
            _context = context;
        }

        public async Task<List<DisabilityDto>> GetAllDisabilitiesAsync()
        {
            var disabilities = await _context.Disabilities
                .Select(d => new DisabilityDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description
                })
                .ToListAsync();

            return disabilities;
        }
    }
}
