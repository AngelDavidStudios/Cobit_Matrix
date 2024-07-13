using Cobit_Matrix.Models;
using Cobit_Matrix.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cobit_Matrix.Controllers
{
    public class GoalAlignmentController : Controller
    {
        private readonly GoalAlignAPIService _goalAlignAPIService;

        public GoalAlignmentController(GoalAlignAPIService goalAlignAPIService)
        {
            _goalAlignAPIService = goalAlignAPIService;
        }

        public async Task<IActionResult> Index()
        {
            var goalAlignments = await _goalAlignAPIService.GetGoalAlignmentsAsync();
            return View(goalAlignments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var goalAlignment = await _goalAlignAPIService.GetGoalAlignmentAsync(id);
            if (goalAlignment == null)
            {
                return NotFound();
            }
            return View(goalAlignment);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MetaAlineamiento goalAlignment)
        {
            if (ModelState.IsValid)
            {
                await _goalAlignAPIService.CreateGoalAlignmentAsync(goalAlignment);
                return RedirectToAction(nameof(Index));
            }
            return View(goalAlignment);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var goalAlignment = await _goalAlignAPIService.GetGoalAlignmentAsync(id);
            if (goalAlignment == null)
            {
                return NotFound();
            }
            return View(goalAlignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MetaAlineamiento goalAlignment)
        {
            if (id != goalAlignment.IdAlineamiento)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _goalAlignAPIService.UpdateGoalAlignmentAsync(id, goalAlignment);
                return RedirectToAction(nameof(Index));
            }
            return View(goalAlignment);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var goalAlignment = await _goalAlignAPIService.GetGoalAlignmentAsync(id);
            if (goalAlignment == null)
            {
                return NotFound();
            }
            return View(goalAlignment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _goalAlignAPIService.DeleteGoalAlignmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}