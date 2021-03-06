using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaSocios.Data;
using SistemaSocios.Modelo;

namespace SistemaSocios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoesController : ControllerBase
    {
        private readonly SistemaSociosContext _context;

        public MovimientoesController(SistemaSociosContext context)
        {
            _context = context;
        }

        // GET: api/Movimientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimiento>>> GetMovimiento()
        {
            return await _context.Movimiento.ToListAsync();
        }

        // GET: api/Movimientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movimiento>> GetMovimiento(int id)
        {
            var movimiento = await _context.Movimiento.FindAsync(id);

            if (movimiento == null)
            {
                return NotFound();
            }

            return movimiento;
        }

        // PUT: api/Movimientoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimiento(int id, Movimiento movimiento)
        {
            if (id != movimiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(movimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientoExists(id))
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

        // POST: api/Movimientoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movimiento>> PostMovimiento(Movimiento movimiento)
        {
            _context.Movimiento.Add(movimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimiento", new { id = movimiento.Id }, movimiento);
        }

        // DELETE: api/Movimientoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movimiento>> DeleteMovimiento(int id)
        {
            var movimiento = await _context.Movimiento.FindAsync(id);
            if (movimiento == null)
            {
                return NotFound();
            }

            _context.Movimiento.Remove(movimiento);
            await _context.SaveChangesAsync();

            return movimiento;
        }

        private bool MovimientoExists(int id)
        {
            return _context.Movimiento.Any(e => e.Id == id);
        }
    }
}
