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
}