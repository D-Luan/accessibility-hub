using AccessibilityHub.Entities.Models;
using AccessibilityHub.WebApp.Services;
using AccessibilityHub.WebApp.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Controllers;

public class ResourceController : Controller
{
    private readonly IResourceService _resourceService;

    public ResourceController(IResourceService resourceService)
    {
        _resourceService = resourceService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var resources = await _resourceService.GetAllResourcesAsync();
        return View(resources);
    }

    [HttpGet]
    public async Task<ActionResult<ResourceDto>> Details(int id)
    {
        var resource = await _resourceService.GetResourceByIdAsync(id);

        if (resource == null)
        {
            return NotFound();
        }

        return View(resource);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult<ResourceDto>> Create([Bind("Name, Description, Url, Category, DisabilityId")] CreateResourceDto createDto)
    {
        if (ModelState.IsValid)
        {
            var createdResource = await _resourceService.CreateResourceAsync(createDto);
            return RedirectToAction(nameof(Details), new {id = createdResource.Id});
        }

        return View(createDto);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var resourceToEdit = await _resourceService.GetResourceForUpdateAsync(id.Value);
        
        if (resourceToEdit == null)
        {
            return NotFound();
        }

        return View(resourceToEdit);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description, Url, Category")] UpdateResourceDto updateDto)
    {
        if (id != updateDto.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var success = await _resourceService.UpdateResourceAsync(id, updateDto);

                if (!success)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "Unable to save changes. The resource may have been modified or deleted by another user.");
            }
        }

        return View(updateDto);
    }
}
