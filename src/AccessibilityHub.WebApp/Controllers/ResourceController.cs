using AccessibilityHub.Entities.Models;
using AccessibilityHub.WebApp.Services;
using AccessibilityHub.WebApp.Dtos;
using AccessibilityHub.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AccessibilityHub.WebApp.Controllers;

public class ResourceController : Controller
{
    private readonly IResourceService _resourceService;
    private readonly IDisabilityService _disabilityService;

    public ResourceController(IResourceService resourceService, IDisabilityService disabilityService)
    {
        _resourceService = resourceService;
        _disabilityService = disabilityService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int disabilityId)
    {
        var disability = await _disabilityService.GetDisabilityByIdAsync(disabilityId);
        if (disability == null)
        {
            return NotFound();
        }

        var resources = await _resourceService.GetAllResourcesAsync();

        var viewModel = new DisabilityResourcesViewModel
        {
            DisabilityId = disability.Id,
            DisabilityName = disability.Name,
            Resources = resources
        };

        return View(viewModel);
    }

    [HttpGet]
    public async Task<ActionResult<ResourceDto>> Details(int disabilityId, int id)
    {
        var resource = await _resourceService.GetResourceByIdAsync(id);

        if (resource == null)
        {
            return NotFound();
        }

        var model = new ResourceByIdViewModel
        {
            DisabilityId = disabilityId,
            Resource = resource
        };

        return View(model);
    }

    [HttpGet]
    public IActionResult Create(int disabilityId)
    {
        var model = new CreateResourceDto
        {
            DisabilityId = disabilityId
        };

        return View(model);
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
    public async Task<IActionResult> Edit(int disabilityId, int? id)
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

        var model = new ResourceEditViewModel
        {
            DisabilityId = disabilityId,
            Resource = resourceToEdit
        };

        return View(model);
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

    [HttpGet]
    public async Task<IActionResult> Delete(int disabilityId, int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var resourceToDelete = await _resourceService.GetDeleteResourceById(id.Value);
        if (resourceToDelete == null)
        {
            return NotFound();
        }

        var model = new ResourceByIdViewModel
        {
            DisabilityId = disabilityId,
            Resource = resourceToDelete
        };

        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteResourceConfirmed(int id)
    {
        var resourceToDelete = await _resourceService.DeleteResource(id);

        if (!resourceToDelete)
        {
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }
}
