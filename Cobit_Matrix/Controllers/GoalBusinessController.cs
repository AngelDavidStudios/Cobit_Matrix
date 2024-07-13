using Cobit_Matrix.Models;
using Cobit_Matrix.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cobit_Matrix.Controllers
{
    public class GoalBusinessController : Controller
    {
        private readonly GoalBusinessAPIService _goalBusinessAPIService;

        public GoalBusinessController(GoalBusinessAPIService goalBusinessAPIService)
        {
            _goalBusinessAPIService = goalBusinessAPIService;
        }

        public async Task<IActionResult> Index()
        {
            var goalBusinesses = await _goalBusinessAPIService.GetGoalBusinessesAsync();
            return View(goalBusinesses);
        }

        public async Task<IActionResult> Details(int id)
        {
            var goalBusiness = await _goalBusinessAPIService.GetGoalBusinessAsync(id);
            if (goalBusiness == null)
            {
                return NotFound();
            }
            return View(goalBusiness);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MetaEmpresarial goalBusiness)
        {
            if (ModelState.IsValid)
            {
                await _goalBusinessAPIService.CreateGoalBusinessAsync(goalBusiness);
                return RedirectToAction(nameof(Index));
            }
            return View(goalBusiness);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var goalBusiness = await _goalBusinessAPIService.GetGoalBusinessAsync(id);
            if (goalBusiness == null)
            {
                return NotFound();
            }
            return View(goalBusiness);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MetaEmpresarial goalBusiness)
        {
            if (id != goalBusiness.IdEmpresarial)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _goalBusinessAPIService.UpdateGoalBusinessAsync(id, goalBusiness);
                return RedirectToAction(nameof(Index));
            }
            return View(goalBusiness);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var goalBusiness = await _goalBusinessAPIService.GetGoalBusinessAsync(id);
            if (goalBusiness == null)
            {
                return NotFound();
            }
            return View(goalBusiness);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _goalBusinessAPIService.DeleteGoalBusinessAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}