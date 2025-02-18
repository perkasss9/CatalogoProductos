
namespace CatalogoProductos.Models;

public class Product
{
    public int _id;
    public string _nombre;
    public string _descripcion;
    public double? _precio;
    public int? _idCategoria;

    public int Id {
        get => _id;
        set
        {
            if (int.IsNegative(value))
            {
                throw new Exception("El ID del producto no puede ser negativo");
            }
            else if (_id != value)
            {
                _id = value;
            }
        }
    }
    public string Nombre { 
        get => _nombre; 
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("El nombre del producto no puede estar vacío");
            }
            else if (_nombre != value)
            {
                _nombre = value;
            }
        }
    }
    public string Descripcion { 
        get => _descripcion; 
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("La descripción del producto no puede estar vacía");
            }
            else if (_descripcion != value)
            {
                _descripcion = value;
            }
        }
    }
    public double? Precio
    {
        get => _precio;
        set
        {
            if (value.HasValue && value.Value < 0)
            {
                throw new Exception("El precio del producto no puede ser negativo");
            }
            else if (_precio != value)
            {
                _precio = value;
            }
        }
    }

    public int? IdCategoria
    {
        get => _idCategoria;
        set
        {
            if (value.HasValue && value.Value < 0)
            {
                throw new Exception("El ID de la categoría no puede ser negativo");
            }
            else if (_idCategoria != value)
            {
                _idCategoria = value;
            }
        }
    }
}
