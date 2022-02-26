#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPCoreAPI_study;
using ASPCoreAPI_study.Data;

namespace ASPCoreAPI_study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroesv2Controller : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroesv2Controller(DataContext context)
        {
            _context = context;
        }

        // GET: api/SuperHeroesv2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperHero>>> GetSuperHeros()
        {
            return await _context.SuperHeros.ToListAsync();
        }

        // GET: api/SuperHeroesv2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSuperHero(int id)
        {
            var superHero = await _context.SuperHeros.FindAsync(id);

            if (superHero == null)
            {
                return NotFound("Hero not found.");
            }

            return superHero;
        }

        // PUT: api/SuperHeroesv2/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperHero(int id, SuperHero superHero)
        {
            if (id != superHero.Id)
            {
                return BadRequest();
            }

            _context.Entry(superHero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuperHeroExists(id))
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

        // POST: api/SuperHeroesv2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SuperHero>> PostSuperHero(SuperHero superHero)
        {
            _context.SuperHeros.Add(superHero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuperHero", new { id = superHero.Id }, superHero);
        }

        // DELETE: api/SuperHeroesv2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHero(int id)
        {
            var superHero = await _context.SuperHeros.FindAsync(id);
            if (superHero == null)
            {
                return NotFound("Hero not found.");
            }

            _context.SuperHeros.Remove(superHero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuperHeroExists(int id)
        {
            return _context.SuperHeros.Any(e => e.Id == id);
        }
    }
}
