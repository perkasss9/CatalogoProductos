using CatalogoProductos.Models;
using CatalogoProductos.Repositories;

namespace CatalogoProductos.Services;

public class ProductService : IRepositoryService<Product>
{
    private readonly IRepository<Product> _repositoryProducts;

    public ProductService(IRepository<Product> repositorioProductos)
    {
        _repositoryProducts = repositorioProductos;
    }

    public void Add(Product item) => _repositoryProducts.Add(item);

    public void Delete(Product item) => _repositoryProducts.Delete(item);

    public Product Get(int id) => _repositoryProducts.Get(id);

    public IEnumerable<Product> GetAll() => _repositoryProducts.GetAll();

    public void Update(Product item) => _repositoryProducts.Update(item);
}
