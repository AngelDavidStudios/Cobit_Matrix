using Cobit_Matrix.Models;
using MatrixCobit_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cobit_Matrix.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalBusinessController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GoalBusinessController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaEmpresarial>>> GetGoalBusiness()
        {
            return await _context.GoalBussiness.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetaEmpresarial>> GetGoalBusiness(int id)
        {
            var goalBusiness = await _context.GoalBussiness.FindAsync(id);

            if (goalBusiness == null)
            {
                return NotFound();
            }

            return goalBusiness;
        }

        [HttpPost]
        public async Task<ActionResult<MetaEmpresarial>> PostGoalBusiness(MetaEmpresarial goalBusiness)
        {
            _context.GoalBussiness.Add(goalBusiness);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGoalBusiness), new { id = goalBusiness.IdEmpresarial }, goalBusiness);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoalBusiness(int id, MetaEmpresarial goalBusiness)
        {
            if (id != goalBusiness.IdEmpresarial)
            {
                return BadRequest();
            }

            _context.Entry(goalBusiness).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalBusinessExists(id))
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
        public async Task<IActionResult> DeleteGoalBusiness(int id)
        {
            var goalBusiness = await _context.GoalBussiness.FindAsync(id);
            if (goalBusiness == null)
            {
                return NotFound();
            }

            _context.GoalBussiness.Remove(goalBusiness);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GoalBusinessExists(int id)
        {
            return _context.GoalBussiness.Any(e => e.IdEmpresarial == id);
        }
    }
}