using CatalogoProductos.Models;
using CatalogoProductos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace CatalogoProductos.ViewModels;

public partial class ProductoViewModel(IRepositoryService<Product> productService) : ObservableObject
{

    [ObservableProperty]
    private ObservableCollection<Product> _productos = new(productService.GetAll());

    [ObservableProperty]
    private Product? _productoSeleccionado = null;

    [ObservableProperty]
    private int? _id = null;

    [ObservableProperty]
    private String? _nombre = String.Empty;

    [ObservableProperty]
    private double? _precio = null;

    [ObservableProperty]
    private String? _descripcion = String.Empty;

    [ObservableProperty]
    private int? _idCategoria = null;

    private bool CanAddProducto => (ProductoSeleccionado == null && Id == null && !string.IsNullOrEmpty(Nombre) && Precio != null && !string.IsNullOrEmpty(Descripcion) && IdCategoria != null);

    partial void OnNombreChanged(string? value)
    {
        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
    }

    partial void OnDescripcionChanged(string? value)
    {
        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
    }

    partial void OnPrecioChanged(double? value)
    {
        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
    }

    partial void OnIdCategoriaChanged(int? value)
    {
        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
    }

    partial void OnProductoSeleccionadoChanged(Product? productoSeleccionado)
    {
        if (productoSeleccionado != null)
        {
            Id = productoSeleccionado.Id;
            Nombre = productoSeleccionado.Nombre;
            Descripcion = productoSeleccionado.Descripcion;
            Precio = productoSeleccionado.Precio;
            IdCategoria = productoSeleccionado.IdCategoria;
        }
        else
        {
            Id = null;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            Precio = null;
            IdCategoria = null;
        }

        OnPropertyChanged(nameof(CanAddProducto));
        AddProductoCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanAddProducto))]
    private void AddProducto()
    {
        productService.Add(new Product
        {
            Nombre = Nombre,
            Precio = Precio,
            Descripcion = Descripcion,
            IdCategoria = IdCategoria
        });
        Productos = new ObservableCollection<Product>(productService.GetAll());
        Nombre = String.Empty;
        Descripcion = String.Empty;
        Id = null;
        Precio = null;
        IdCategoria = null;
    }

    [RelayCommand]
    private void UpdateProducto()
    {
        Product producto = ProductoSeleccionado;
        producto.Nombre = Nombre;
        producto.Descripcion = Descripcion;
        producto.Precio = Precio;
        producto.IdCategoria = IdCategoria;
        productService.Update(producto);
        Productos = new ObservableCollection<Product>(productService.GetAll());
    }

    [RelayCommand]
    private void DeleteProducto()
    {
        productService.Delete(ProductoSeleccionado);
        Productos = new ObservableCollection<Product>(productService.GetAll());
    }

}