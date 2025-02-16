using CatalogoProductos.Data;
using CatalogoProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProductos.Repositories;

public class ProductRepository(AppDbContext context) : IRepository<Product>
{
    private readonly AppDbContext _context = context;

    public void Add(Product item)
    {
        _context.Add(item);
        _context.SaveChanges();
    }

    public void Delete(Product item)
    {
        _context.Remove(item);
        _context.SaveChanges();
    }

    public Product Get(int id) => _context.Products.ToList<Product>().Find(c => c.Id == id);

    public IEnumerable<Product> GetAll() => _context.Products.ToList();

    public void Update(Product item)
    {
        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();
    }

}
