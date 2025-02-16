
namespace CatalogoProductos.Models;

public class Category
{
    public int _id { get; set; }
    public string _nombre { get; set; }
    public string _descripcion { get; set; }

    public int Id
    {
        get => _id;
        set
        {
            if (int.IsNegative(value))
            {
                throw new Exception("El ID de la categoría no puede ser negativo");
            }
            else if (_id != value)
            {
                _id = value;
            }
        }
    }

    public string Nombre
    {
        get => _nombre;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("El nombre de la categoría no puede estar vacío");
            }
            else if (_nombre != value)
            {
                _nombre = value;
            }
        }
    }

    public string Descripcion
    {
        get => _descripcion;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("La descripción de la categoría no puede estar vacía");
            }
            else if (_descripcion != value)
            {
                _descripcion = value;
            }
        }
    }

}
