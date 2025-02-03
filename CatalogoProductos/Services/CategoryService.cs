using CatalogoProductos.Models;
using CatalogoProductos.Repositories;

namespace CatalogoProductos.Services;

public class CategoryService : IRepositoryService<Category>
{
    private readonly IRepository<Category> _repositoryCategories;

    public CategoryService(IRepository<Category> repositorioCategorias)
    {
        _repositoryCategories = repositorioCategorias;
    }

    public void Add(Category item) => _repositoryCategories.Add(item);

    public void Delete(Category item) => _repositoryCategories.Delete(item);

    public Category Get(int id) => _repositoryCategories.Get(id);

    public IEnumerable<Category> GetAll() => _repositoryCategories.GetAll();

    public void Update(Category item) => _repositoryCategories.Update(item);
}
