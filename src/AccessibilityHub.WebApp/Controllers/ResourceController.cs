using AccessibilityHub.Entities.Models;
using AccessibilityHub.WebApp.Services;
using AccessibilityHub.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AccessibilityHub.WebApp.Controllers;

public class ResourceController : Controller
{
    private readonly IResourceService _resourceService;

    public ResourceController(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    public async Task<IActionResult> Index()
    {
        var resources = await _resourceService.GetAllResourcesAsync();
        return View(resources);
    }

    public async Task<ActionResult<ResourceDto>> Details(int id)
    {
        var resource = await _resourceService.GetResourceByIdAsync(id);

        if (resource == null)
        {
            return NotFound();
        }

        return View(resource);
    }
}
