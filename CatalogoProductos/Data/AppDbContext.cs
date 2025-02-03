using CatalogoProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProductos.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public required virtual DbSet<Product> Products { get; set; }
    public required virtual DbSet<Category> Categories { get; set; }

}

