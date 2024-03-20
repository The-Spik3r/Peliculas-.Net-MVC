using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peliculas.Models.DB;
using System.Collections.Generic;
using System.Linq;


namespace Peliculas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasApiController : ControllerBase
    {
        private readonly PeliculasSqlContext _context;

        public PeliculasApiController(PeliculasSqlContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPeliculas()
        {
            var peliculas = _context.Peliculas.ToList();
            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public IActionResult GetPelicula(int id)
        {
            var pelicula = _context.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return Ok(pelicula);
        }

        [HttpPost]
        public IActionResult CrearPelicula([FromBody] Pelicula pelicula)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPelicula), new { id = pelicula.Id }, pelicula);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarPelicula(int id, [FromBody] Pelicula pelicula)
        {
            if (id != pelicula.Id)
            {
                return BadRequest();
            }

            _context.Entry(pelicula).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPelicula(int id)
        {
            var pelicula = _context.Peliculas.Find(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            _context.Peliculas.Remove(pelicula);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
