using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProductos.Repositories;

interface IRepositories <T>
{
    public void Add(T item);
    public void Update(T item);
    public void Delete(T item);
    public T Get(int id);
    public IEnumerable<T> GetAll();
}
