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
    private string name;

    [ObservableProperty]
    private string description;

    [ObservableProperty]
    private int categoryId;

    [ObservableProperty]
    private double price;

    [RelayCommand]
    private void AddProduct()
    {
        try
        {
            var product = new Product
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Price = Price,
                CategoryId = CategoryId
            };
            _productService.Add(product);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding product: {ex.Message}");
        }
    }
}