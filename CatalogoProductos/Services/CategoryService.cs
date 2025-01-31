using CatalogoProductos.Models;
using CatalogoProductos.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Services;

public class CategoryService : IRepositoryService<Category>
{
    private readonly IRepository<Category> _repositorioCategorias;

    public CategoryService(IRepository<Category> repositorioCategorias)
    {
        _repositorioCategorias = repositorioCategorias;
    }

    public void Add(Category item) => _repositorioCategorias.Add(item);

    public void Delete(Category item) => _repositorioCategorias.Delete(item);

    public Category Get(int id) => _repositorioCategorias.Get(id);

    public IEnumerable<Category> GetAll() => _repositorioCategorias.GetAll();

    public void Update(Category item) => _repositorioCategorias.Update(item);
}
