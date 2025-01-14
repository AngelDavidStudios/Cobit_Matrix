using Cobit_Matrix.Models;
using Cobit_Matrix.Services;
using Cobit_Matrix.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cobit_Matrix.Controllers
{
    public class MatrizController : Controller
    {
        private readonly ApiService<MetaAlineamiento> _metaAlineamientoService;
        private readonly ApiService<MetaEmpresarial> _metaEmpresarialService;
        private readonly ApiService<ObjetivosGobierno> _ObjetivosGobiernoService;

        public MatrizController()
        {
            _metaAlineamientoService = new ApiService<MetaAlineamiento>("http://localhost:5249/api");
            _metaEmpresarialService = new ApiService<MetaEmpresarial>("http://localhost:5249/api");
            _ObjetivosGobiernoService = new ApiService<ObjetivosGobierno>("http://localhost:5249/api");
        }

        public async Task<IActionResult> Index()
        {
            var metaAlineamientos = await _metaAlineamientoService.GetAllAsync("GoalAlignment");
            var metaEmpresariales = await _metaEmpresarialService.GetAllAsync("GoalBusiness");
            var objetivosGobierno = await _ObjetivosGobiernoService.GetAllAsync("ObjeGovernment");

            var viewModel = new MatrizViewModel()
            {
                MetaAlineamientos = metaAlineamientos,
                MetaEmpresariales = metaEmpresariales,
                ObjetivosGobierno = objetivosGobierno
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveHighlightedRows(List<int> highlightedRowIndexes)
        {
            TempData["HighlightedRowIndexes"] = highlightedRowIndexes;
            return RedirectToAction("EditObjMatrix");
        }

        public async Task<IActionResult> EditObjMatrix()
        {
            var metaAlineamientos = await _metaAlineamientoService.GetAllAsync("GoalAlignment");
            var metaEmpresariales = await _metaEmpresarialService.GetAllAsync("GoalBusiness");
            var objetivosGobierno = await _ObjetivosGobiernoService.GetAllAsync("ObjeGovernment");

            var highlightedRowIndexes = TempData["HighlightedRowIndexes"] as List<int> ?? new List<int>();

            var viewModel = new MatrizViewModel()
            {
                MetaAlineamientos = metaAlineamientos,
                MetaEmpresariales = metaEmpresariales,
                ObjetivosGobierno = objetivosGobierno,
                HighlightedRowIndexes = highlightedRowIndexes
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveChanges(List<int> highlightedRowIndexes)
        {
            TempData["HighlightedRowIndexes"] = highlightedRowIndexes;
            return RedirectToAction("Report");
        }

        public async Task<IActionResult> Report()
        {
            var metaAlineamientos = await _metaAlineamientoService.GetAllAsync("GoalAlignment");
            var metaEmpresariales = await _metaEmpresarialService.GetAllAsync("GoalBusiness");
            var objetivosGobierno = await _ObjetivosGobiernoService.GetAllAsync("ObjeGovernment");

            var highlightedRowIndexes = TempData["HighlightedRowIndexes"] as List<int> ?? new List<int>();

            var viewModel = new MatrizViewModel()
            {
                MetaAlineamientos = metaAlineamientos,
                MetaEmpresariales = metaEmpresariales,
                ObjetivosGobierno = objetivosGobierno,
                HighlightedRowIndexes = highlightedRowIndexes
            };

            return View(viewModel);
        }
    }
}
