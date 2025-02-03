using CatalogoProductos.Data;
using CatalogoProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProductos.Repositories;

public class CategoryRepository(AppDbContext context) : IRepository<Category>
{
    private readonly AppDbContext _context = context;

    public void Add(Category item)
    {
        _context.Add(item);
        _context.SaveChanges();
    }

    public void Delete(Category item)
    {
        _context.Remove(item);
        _context.SaveChanges();
    }

    public Category Get(int id) => _context.Categories.Find(id);
    public IEnumerable<Category> GetAll() => _context.Categories.ToList();
    public void Update(Category item)
    {
        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();
    }

}
