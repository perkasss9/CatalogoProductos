using CatalogoProductos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogoProductos.Repositories;


namespace CatalogoProductos.Services;

public class ProductService : IRepositoryService<Product>
{
    private readonly IRepository<Product> _repositorioProductos;

    public ProductService(IRepository<Product> repositorioProductos)
    {
        _repositorioProductos = repositorioProductos;
    }

    public void Add(Product item) => _repositorioProductos.Add(item);

    public void Delete(Product item) => _repositorioProductos.Delete(item);

    public Product Get(int id) => _repositorioProductos.Get(id);

    public IEnumerable<Product> GetAll() => _repositorioProductos.GetAll();

    public void Update(Product item) => _repositorioProductos.Update(item);
}
