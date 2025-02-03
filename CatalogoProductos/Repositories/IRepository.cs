
namespace CatalogoProductos.Repositories;

public interface IRepository <T>
{
    public void Add(T item);
    public void Update(T item);
    public void Delete(T item);
    public T Get(int id);
    public IEnumerable<T> GetAll();
}
