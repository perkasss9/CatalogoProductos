using CatalogoProductos.Models;
using CatalogoProductos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace CatalogoProductos.ViewModels;

public partial class ProductoViewModel : ObservableObject
{
    private readonly ProductService _productService;

    public ProductoViewModel(ProductService productService)
    {
        _productService = productService;
    }

    public ProductoViewModel() { }

    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string nombre;

    [ObservableProperty]
    private string descripcion;

    [ObservableProperty]
    private int categoiaId;

    [ObservableProperty]
    private double precio;

}