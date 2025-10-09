using AccessibilityHub.WebApp.Dtos;
using AccessibilityHub.WebApp.Services;
using AccessibilityHub.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Controllers;

public class ProviderController : Controller
{
    private readonly IProviderService _providerService;
    private readonly IDisabilityService _disabilityService;

    public ProviderController(IProviderService providerService, IDisabilityService disabilityService)
    {
        _providerService = providerService;
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

        var providers = await _providerService.GetDisabilityProvidersByIdAsync(disabilityId);

        var viewModel = new DisabilityProvidersViewModel
        {
            DisabilityId = disability.Id,
            DisabilityName = disability.Name,
            Providers = providers,
        };

        return View(viewModel);
    }

    [HttpGet]
    public async Task<ActionResult> Details(int disabilityId, int id)
    {
        var provider = await _providerService.GetProviderByIdAsync(id);

        if (provider == null)
        {
            return NotFound();
        }

        var model = new ProviderDetailViewModel
        {
            DisabilityId = disabilityId,
            Provider = provider,
        };

        return View(model);
    }

    [HttpGet]
    public IActionResult Create(int disabilityId)
    {
        var model = new CreateProviderDto
        {
            DisabilityId = disabilityId,
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(CreateProviderDto createDto)
    {
        if (ModelState.IsValid)
        {
            var createdProvider = await _providerService.CreateProviderAsync(createDto);
            return RedirectToAction(nameof(Details), new { id = createdProvider.Id, disabilityId = createDto.DisabilityId });
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

        var providerToEdit = await _providerService.GetProviderForUpdateAsync(id.Value);

        if (providerToEdit == null)
        {
            return NotFound();
        }

        var model = new ProviderEditViewModel
        {
            DisabilityId = disabilityId,
            Provider = providerToEdit,
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProviderEditViewModel model)
    {
        if (id != model.Provider.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var success = await _providerService.UpdateProviderAsync(id, model.Provider);

                if (!success)
                {
                    return NotFound();
                }

                return RedirectToAction("Index", new { disabilityId = model.DisabilityId });
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. The Provider may have been modified or deleted by another user.");
            }
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int disabilityId, int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var providerToDelete = await _providerService.GetProviderByIdAsync(id.Value);
        if (providerToDelete == null)
        {
            return NotFound();
        }

        var model = new ProviderDetailViewModel
        {
            DisabilityId = disabilityId,
            Provider = providerToDelete,
        };

        return View(model);
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, int disabilityId)
    {
        var providerToDelete = await _providerService.DeleteProviderAsync(id);

        if (!providerToDelete)
        {
            return NotFound();
        }

        return RedirectToAction("Index", new { disabilityId = disabilityId });
    }
}