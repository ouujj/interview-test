﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Controllers;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnglishesController : ControllerBase
    {
        private readonly ApiModelsContext _context;

        public EnglishesController(ApiModelsContext context)
        {
            _context = context;
        }

        // GET: api/Englishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<English>>> GetEnglishes()
        {
            return await _context.Englishes.ToListAsync();
        }

        // GET: api/Englishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<English>> GetEnglish(long id)
        {
            var english = await _context.Englishes.FindAsync(id);

            if (english == null)
            {
                return NotFound();
            }

            return english;
        }



        // GET: api/Englishes/withthaiall
        [HttpGet("withthaiall")]
        public async Task<ActionResult<List<English>>> GetEnglishesWiththai()
        {
            List<English> englishes;
            englishes = await _context.Englishes.ToListAsync();
            
            int i = 0;
            foreach (var english in englishes)
            {
                Console.WriteLine("English ID is {0} and Word is {1}", english.Id, english.word);

                List<Thai> thais;
                thais = GetThaiByEng(english.Id);
                englishes[i].thais = thais;

                /*
                if (thais.Count > 0) 
                {
                    englishes[i].thais = thais;
                    foreach (var  thai in thais) 
                    {
                      Console.WriteLine(">>> with Thai ID is {0} and Word is {1}", thai.Id, thai.word);
                     
                    }
                }
                */

                i++;
            }
            return englishes;
        }

        public List<Thai> GetThaiByEng(long id)
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


        // PUT: api/Englishes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnglish(long id, English english)
        {
            if (id != english.Id)
            {
                return BadRequest();
            }

            _context.Entry(english).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnglishExists(id))
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

        // POST: api/Englishes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<English>> PostEnglish(English english)
        {
            _context.Englishes.Add(english);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnglish", new { id = english.Id }, english);
        }

        // DELETE: api/Englishes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<English>> DeleteEnglish(long id)
        {
            var english = await _context.Englishes.FindAsync(id);
            if (english == null)
            {
                return NotFound();
            }

            _context.Englishes.Remove(english);
            await _context.SaveChangesAsync();

            return english;
        }

        private bool EnglishExists(long id)
        {
            return _context.Englishes.Any(e => e.Id == id);
        }
    }
}
