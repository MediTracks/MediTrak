using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediTrak.Data;

namespace MediTrak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructuresController : ControllerBase
    {
        private readonly MediTrakContext _context;

        public StructuresController(MediTrakContext context)
        {
            _context = context;
        }

        // GET: api/Structures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Structure>>> GetStructures()
        {
            return await _context.Structures.ToListAsync();
        }
        // GET: api/Structures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Structure>> GetStructureDetails(int id)
        {
            var structure = _context.Structures.Include(str => str.Zone)
                                               .Where(str => str.Id ==id)
                                               .FirstOrDefault();

            if (structure == null)
            {
                return NotFound();
            }

            return structure;
        }

        // GET: api/Structures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Structure>> GetStructure(int id)
        {
            var structure = await _context.Structures.FindAsync(id);

            if (structure == null)
            {
                return NotFound();
            }

            return structure;
        }

        // PUT: api/Structures/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStructure(int id, Structure structure)
        {
            if (id != structure.Id)
            {
                return BadRequest();
            }

            _context.Entry(structure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StructureExists(id))
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

        // POST: api/Structures
        [HttpPost]
        public async Task<ActionResult<Structure>> PostStructure(Structure structure)
        {
            _context.Structures.Add(structure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStructure", new { id = structure.Id }, structure);
        }

        // DELETE: api/Structures/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Structure>> DeleteStructure(int id)
        {
            var structure = await _context.Structures.FindAsync(id);
            if (structure == null)
            {
                return NotFound();
            }

            _context.Structures.Remove(structure);
            await _context.SaveChangesAsync();

            return structure;
        }

        private bool StructureExists(int id)
        {
            return _context.Structures.Any(e => e.Id == id);
        }
    }
}
