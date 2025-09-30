using AccessibilityHub.Entities.Models;
using AccessibilityHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Services;

public interface IDisabilityService
{
    Task<List<Disability>> GetAllDisabilitiesAsync();
    public class DisabilityService : IDisabilityService
    {
        private readonly AccessibilityDbContext _context;

        public DisabilityService(AccessibilityDbContext context)
        {
            _context = context;
        }

        public async Task<List<Disability>> GetAllDisabilitiesAsync()
        {
            return await _context.Disabilities.ToListAsync();
        }
    }
}
