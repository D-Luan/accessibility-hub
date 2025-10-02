using AccessibilityHub.Entities.Models;
using AccessibilityHub.Infrastructure.Data;
using AccessibilityHub.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Services;

public interface IResourceService
{
    public class ResourceService : IResourceService
    {
        private readonly AccessibilityDbContext _context;

        public ResourceService(AccessibilityDbContext context)
        {
            _context = context;
        }
    }
}
