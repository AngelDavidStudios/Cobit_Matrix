using Cobit_Matrix.Data;
using Cobit_Matrix.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cobit_Matrix.Controllers;

public class GoalAlignmentController: Controller
{
    private readonly AppDbContext _context;

        public GoalAlignmentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GoalAlignment
        public async Task<IActionResult> Index()
        {
            return View(await _context.GoalAlignment.ToListAsync());
        }

        // GET: GoalAlignment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalAlignment = await _context.GoalAlignment
                .FirstOrDefaultAsync(m => m.IdAlineamiento == id);
            if (goalAlignment == null)
            {
                return NotFound();
            }

            return View(goalAlignment);
        }

        // GET: GoalAlignment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GoalAlignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Descripcion")] MetaAlineamiento goalAlignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goalAlignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goalAlignment);
        }

        // GET: GoalAlignment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalAlignment = await _context.GoalAlignment.FindAsync(id);
            if (goalAlignment == null)
            {
                return NotFound();
            }
            return View(goalAlignment);
        }

        // POST: GoalAlignment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Descripcion")] MetaAlineamiento goalAlignment)
        {
            if (id != goalAlignment.IdAlineamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goalAlignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoalAlignmentExists(goalAlignment.IdAlineamiento))
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
            return View(goalAlignment);
        }

        // GET: GoalAlignment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goalAlignment = await _context.GoalAlignment
                .FirstOrDefaultAsync(m => m.IdAlineamiento == id);
            if (goalAlignment == null)
            {
                return NotFound();
            }

            return View(goalAlignment);
        }

        // POST: GoalAlignment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goalAlignment = await _context.GoalAlignment.FindAsync(id);
            _context.GoalAlignment.Remove(goalAlignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoalAlignmentExists(int id)
        {
            return _context.GoalAlignment.Any(e => e.IdAlineamiento == id);
        }
}