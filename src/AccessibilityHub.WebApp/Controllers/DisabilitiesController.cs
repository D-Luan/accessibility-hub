using AccessibilityHub.Entities.Models;
using AccessibilityHub.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccessibilityHub.WebApp.Controllers;

public class DisabilitiesController : Controller
{
    private readonly IDisabilityService _disabilityService;

    public DisabilitiesController(IDisabilityService disabilityService)
    {
        _disabilityService = disabilityService;
    }

    public async Task<IActionResult> Index()
    {
        var disabilities = await _disabilityService.GetAllDisabilitiesAsync();
        return View(disabilities);
    }
}
