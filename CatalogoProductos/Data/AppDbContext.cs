using CatalogoProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProductos.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public required virtual DbSet<Product> Products { get; set; }
    public required virtual DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Category>()
            .ToTable("categories")
            .Property(c => c.Id)
            .HasColumnName("id");

        modelBuilder.Entity<Category>()
            .ToTable("categories")
            .Property(c => c.Nombre)
            .HasColumnName("nombre");

        modelBuilder.Entity<Category>()
            .ToTable("categories")
            .Property(c => c.Descripcion)
            .HasColumnName("descripcion");

        modelBuilder.Entity<Product>()
           .ToTable("products")
           .Property(c => c.Id)
           .HasColumnName("id");

        modelBuilder.Entity<Product>()
           .ToTable("products")
           .Property(e => e.Nombre)
           .HasColumnName("nombre");

        modelBuilder.Entity<Product>()
            .ToTable("products")
            .Property(e => e.Descripcion)
            .HasColumnName("descripcion");

         modelBuilder.Entity<Product>()
            .ToTable("products")
            .Property(e => e.Precio)
            .HasColumnName("precio");

        modelBuilder.Entity<Product>()
            .ToTable("products")
            .Property(e => e.IdCategoria)
            .HasColumnName("id_categoria");

    }

}

