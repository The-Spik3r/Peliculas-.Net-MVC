using Microsoft.AspNetCore.Mvc;
using Peliculas.Models;
using Peliculas.Models.DB;
using System.Linq;

namespace Peliculas.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly PeliculasSqlContext _context;

        public PeliculasController(PeliculasSqlContext context)
        {
            _context = context;
        }

        public IActionResult Pelicula()
        {
            // Consulta para obtener las películas de la base de datos
            var peliculas = _context.Peliculas.Select(p => new Pelicula
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Descripcion = p.Descripcion,
                Enlace = p.Enlace,
                PosterUrl = p.PosterUrl // Utiliza el nombre correcto de la columna en la base de datos
            }).ToList();

            // Pasar las películas a la vista
            return View(peliculas);
        }
    }
}
