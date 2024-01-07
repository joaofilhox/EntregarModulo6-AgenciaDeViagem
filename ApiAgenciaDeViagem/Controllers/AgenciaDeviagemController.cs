using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgenciaDeViagem.Data;
using AgenciaDeViagem.Model;

namespace AgenciaDeViagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciaDeviagemController : ControllerBase
    {
        private readonly DataContext _context;

        public AgenciaDeviagemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destino>>> GetDestinos()
        {
            try
            {
                return await _context.AgenciaDeViagem.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Destino>> GetDestino(int id)
        {
            try
            {
                var destino = await _context.AgenciaDeViagem.FindAsync(id);

                if (destino == null)
                {
                    return NotFound("Destino não encontrado.");
                }

                return destino;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Destino>> PostDestino(Destino destino)
        {
            try
            {
                _context.AgenciaDeViagem.Add(destino);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetDestino), new { id = destino.Id }, destino);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDestino(int id, Destino destino)
        {
            try
            {
                if (id != destino.Id)
                {
                    return BadRequest("O ID na URL não corresponde ao ID no objeto Destino.");
                }

                var existingDestino = await _context.AgenciaDeViagem.FindAsync(id);

                if (existingDestino == null)
                {
                    return NotFound("Destino não encontrado.");
                }

                existingDestino.DestinoName = destino.DestinoName;
                existingDestino.DestinoGenre = destino.DestinoGenre;
                existingDestino.DestinoURL = destino.DestinoURL;
                existingDestino.DestinoPrice = destino.DestinoPrice;


                _context.Entry(existingDestino).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestino(int id)
        {
            try
            {
                var destino = await _context.AgenciaDeViagem.FindAsync(id);
                if (destino == null)
                {
                    return NotFound("Destino não encontrado.");
                }

                _context.AgenciaDeViagem.Remove(destino);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        private bool DestinoExists(int id)
        {
            return _context.AgenciaDeViagem.Any(e => e.Id == id);
        }
    }
}
