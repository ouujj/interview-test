using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThaisController : ControllerBase
    {
        private readonly ApiModelsContext _context;

        public ThaisController(ApiModelsContext context)
        {
            _context = context;
        }

        // GET: api/Thais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thai>>> GetThais()
        {
            return await _context.Thais.ToListAsync();
        }

        // GET: api/Thais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thai>> GetThai(long id)
        {
            var thai = await _context.Thais.FindAsync(id);

            if (thai == null)
            {
                return NotFound();
            }
            else
            {
                //Console.WriteLine("Id {0} Word {1}",thai.Id ,thai.word);
            }
            return thai;
        }

        // GET: api/Thais/findByEngId/5
        [HttpGet("findByEngId/{id}")]
        public  List<Thai> GetThaiByEngId(long id)
        {
            var thaiList = _context.Thais.Where(t => t.EngId == id).Select(tt => new Thai
            {
                Id = tt.Id,
                word = tt.word,
                English = null,
                EngId = tt.EngId

            }).ToList();

            return thaiList;
        }

        // PUT: api/Thais/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThai(long id, Thai thai)
        {
            if (id != thai.Id)
            {
                return BadRequest();
            }

            _context.Entry(thai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThaiExists(id))
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

        // POST: api/Thais
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Thai>> PostThai(Thai thai)
        {
            _context.Thais.Add(thai);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThai", new { id = thai.Id }, thai);
        }

        // DELETE: api/Thais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Thai>> DeleteThai(long id)
        {
            var thai = await _context.Thais.FindAsync(id);
            if (thai == null)
            {
                return NotFound();
            }

            _context.Thais.Remove(thai);
            await _context.SaveChangesAsync();

            return thai;
        }

        private bool ThaiExists(long id)
        {
            return _context.Thais.Any(e => e.Id == id);
        }
    }
}
