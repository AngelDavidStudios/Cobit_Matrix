using Cobit_Matrix.Models;
using MatrixCobit_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cobit_Matrix.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalAlignmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GoalAlignmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetaAlineamiento>>> GetGoalAlignments()
        {
            return await _context.GoalAlignment.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MetaAlineamiento>> GetGoalAlignment(int id)
        {
            var goalAlignment = await _context.GoalAlignment.FindAsync(id);

            if (goalAlignment == null)
            {
                return NotFound();
            }

            return goalAlignment;
        }

        [HttpPost]
        public async Task<ActionResult<MetaAlineamiento>> PostGoalAlignment(MetaAlineamiento goalAlignment)
        {
            _context.GoalAlignment.Add(goalAlignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGoalAlignment), new { id = goalAlignment.IdAlineamiento }, goalAlignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoalAlignment(int id, MetaAlineamiento goalAlignment)
        {
            if (id != goalAlignment.IdAlineamiento)
            {
                return BadRequest();
            }

            _context.Entry(goalAlignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoalAlignmentExists(id))
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
        public async Task<IActionResult> DeleteGoalAlignment(int id)
        {
            var goalAlignment = await _context.GoalAlignment.FindAsync(id);
            if (goalAlignment == null)
            {
                return NotFound();
            }

            _context.GoalAlignment.Remove(goalAlignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GoalAlignmentExists(int id)
        {
            return _context.GoalAlignment.Any(e => e.IdAlineamiento == id);
        }
    }
}