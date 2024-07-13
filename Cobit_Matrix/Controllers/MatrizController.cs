using Cobit_Matrix.Data;
using Cobit_Matrix.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cobit_Matrix.Controllers;

public class MatrizController: Controller
{
    private readonly AppDbContext _context;

    public MatrizController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new MatrizViewModel()
        {
            MetasEmpresariales = await _context.GoalBussiness.ToListAsync(),
            MetasAlineamiento = await _context.GoalAlignment.ToListAsync()
        };

        return View(viewModel);
    }
}