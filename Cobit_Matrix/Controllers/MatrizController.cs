using Cobit_Matrix.Models;
using Cobit_Matrix.Services;
using Cobit_Matrix.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cobit_Matrix.Controllers;

public class MatrizController: Controller
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
}