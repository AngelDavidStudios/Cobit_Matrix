using Cobit_Matrix.Data;
using Cobit_Matrix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cobit_Matrix.Controllers;

public class GoalBusinessController: Controller
{
    private readonly AppDbContext _context;
    
    public GoalBusinessController(AppDbContext context)
    {
        _context = context;
    }
    
    // GET: GoalBusiness
    public async Task<IActionResult> Index()
    {
        return View(await _context.GoalBussiness.ToListAsync());
    }

    // GET: GoalBusiness/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var goalBusiness = await _context.GoalBussiness
            .FirstOrDefaultAsync(m => m.IdEmpresarial == id);
        if (goalBusiness == null)
        {
            return NotFound();
        }

        return View(goalBusiness);
    }

    // GET: GoalBusiness/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: GoalBusiness/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IdEmpresarial,Codigo,Descripcion")] MetaEmpresarial goalBusiness)
    {
        if (ModelState.IsValid)
        {
            _context.Add(goalBusiness);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(goalBusiness);
    }

    // GET: GoalBusiness/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var goalBusiness = await _context.GoalBussiness.FindAsync(id);
        if (goalBusiness == null)
        {
            return NotFound();
        }
        return View(goalBusiness);
    }

    // POST: GoalBusiness/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IdEmpresarial,Codigo,Descripcion")] MetaEmpresarial goalBusiness)
    {
        if (id != goalBusiness.IdEmpresarial)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(goalBusiness);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalBusinessExists(goalBusiness.IdEmpresarial))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(goalBusiness);
    }

    // GET: GoalBusiness/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var goalBusiness = await _context.GoalBussiness
            .FirstOrDefaultAsync(m => m.IdEmpresarial == id);
        if (goalBusiness == null)
        {
            return NotFound();
        }

        return View(goalBusiness);
    }

    // POST: GoalBusiness/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var goalBusiness = await _context.GoalBussiness.FindAsync(id);
        _context.GoalBussiness.Remove(goalBusiness);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool GoalBusinessExists(int id)
    {
        return _context.GoalBussiness.Any(e => e.IdEmpresarial == id);
    }
}