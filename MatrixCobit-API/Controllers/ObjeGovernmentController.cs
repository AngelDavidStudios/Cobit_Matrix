using Cobit_Matrix.Models;
using MatrixCobit_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cobit_Matrix.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ObjeGovernmentController: ControllerBase
{
    private readonly AppDbContext _context;
    
    public ObjeGovernmentController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ObjetivosGobierno>>> GetObjetivosGobierno()
    {
        return await _context.GovernmentObjectives.ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ObjetivosGobierno>> GetObjetivosGobierno(int id)
    {
        var objetivosGobierno = await _context.GovernmentObjectives.FindAsync(id);
        
        if (objetivosGobierno == null)
        {
            return NotFound();
        }
        
        return objetivosGobierno;
    }
    
    [HttpPost]
    public async Task<ActionResult<ObjetivosGobierno>> PostObjetivosGobierno(ObjetivosGobierno objetivosGobierno)
    {
        _context.GovernmentObjectives.Add(objetivosGobierno);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetObjetivosGobierno), new { id = objetivosGobierno.IdGobierno }, objetivosGobierno);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutObjetivosGobierno(int id, ObjetivosGobierno objetivosGobierno)
    {
        if (id != objetivosGobierno.IdGobierno)
        {
            return BadRequest();
        }
        
        _context.Entry(objetivosGobierno).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ObjetivosGobiernoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteObjetivosGobierno(int id)
    {
        var objetivosGobierno = await _context.GovernmentObjectives.FindAsync(id);
        
        if (objetivosGobierno == null)
        {
            return NotFound();
        }
        
        _context.GovernmentObjectives.Remove(objetivosGobierno);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    private bool ObjetivosGobiernoExists(int id)
    {
        return _context.GovernmentObjectives.Any(e => e.IdGobierno == id);
    }
}