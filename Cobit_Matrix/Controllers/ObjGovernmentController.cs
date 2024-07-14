using Cobit_Matrix.Models;
using Cobit_Matrix.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cobit_Matrix.Controllers;

public class ObjGovernmentController: Controller
{
    private readonly ObjGovernAPIService _objGovernmentAPIService;
    
    public ObjGovernmentController(ObjGovernAPIService objGovernmentAPIService)
    {
        _objGovernmentAPIService = objGovernmentAPIService;
    }
    
    public async Task<IActionResult> Index()
    {
        var objGovernments = await _objGovernmentAPIService.GetObjGovernAsync();
        return View(objGovernments);
    }
    
    public async Task<IActionResult> Details(int id)
    {
        var objGovernment = await _objGovernmentAPIService.GetObjGovernAsync(id);
        if (objGovernment == null)
        {
            return NotFound();
        }
        return View(objGovernment);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ObjetivosGobierno objGovernment)
    {
        if (ModelState.IsValid)
        {
            await _objGovernmentAPIService.CreateObjGovernAsync(objGovernment);
            return RedirectToAction(nameof(Index));
        }
        return View(objGovernment);
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var objGovernment = await _objGovernmentAPIService.GetObjGovernAsync(id);
        if (objGovernment == null)
        {
            return NotFound();
        }
        return View(objGovernment);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ObjetivosGobierno objGovernment)
    {
        if (id != objGovernment.IdGobierno)
        {
            return NotFound();
        }
        
        if (ModelState.IsValid)
        {
            await _objGovernmentAPIService.UpdateObjGovernAsync(id, objGovernment);
            return RedirectToAction(nameof(Index));
        }
        return View(objGovernment);
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var objGovernment = await _objGovernmentAPIService.GetObjGovernAsync(id);
        if (objGovernment == null)
        {
            return NotFound();
        }
        return View(objGovernment);
    }
    
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _objGovernmentAPIService.DeleteObjGovernAsync(id);
        return RedirectToAction(nameof(Index));
    }
}