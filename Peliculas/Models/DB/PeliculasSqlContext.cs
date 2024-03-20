using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Peliculas.Models.DB;

public partial class PeliculasSqlContext : DbContext
{
    public PeliculasSqlContext()
    {
    }

    public PeliculasSqlContext(DbContextOptions<PeliculasSqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-279FBV5\\SQLEXPRESS; Database=PeliculasSQL; trusted_Connection=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pelicula__3214EC07421094EF");

            entity.Property(e => e.Enlace).HasMaxLength(200);
            entity.Property(e => e.Titulo).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
