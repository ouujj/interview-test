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
    public class chartsController : ControllerBase
    {
        private readonly ApiModelsContext _context;

        public chartsController(ApiModelsContext context)
        {
            _context = context;
        }

        // GET: api/charts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<chart>>> Getcharts()
        {
            return await _context.charts.ToListAsync();
        }

        // GET: api/charts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<chart>> Getchart(int id)
        {
            var chart = await _context.charts.FindAsync(id);

            if (chart == null)
            {
                return NotFound();
            }

            return chart;
        }

        // PUT: api/charts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Putchart(int id, chart chart)
        {
            if (id != chart.ID)
            {
                return BadRequest();
            }

            _context.Entry(chart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!chartExists(id))
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

        // POST: api/charts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<chart>> Postchart(chart chart)
        {
            _context.charts.Add(chart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getchart", new { id = chart.ID }, chart);
        }

        // DELETE: api/charts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<chart>> Deletechart(int id)
        {
            var chart = await _context.charts.FindAsync(id);
            if (chart == null)
            {
                return NotFound();
            }

            _context.charts.Remove(chart);
            await _context.SaveChangesAsync();

            return chart;
        }

        private bool chartExists(int id)
        {
            return _context.charts.Any(e => e.ID == id);
        }
    }
}
