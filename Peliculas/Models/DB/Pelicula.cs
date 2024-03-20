using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Peliculas.Models.DB;

public partial class Pelicula
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Enlace { get; set; } = null!;

    [Column("poster_url")] // Especifica el nombre de la columna en la base de datos
    public string PosterUrl { get; set; }
}
