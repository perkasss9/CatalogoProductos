using CatalogoProductos.Models;
using CatalogoProductos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
namespace CatalogoProductos.ViewModels;

public partial class CategoriaViewModel(IRepositoryService<Category> categoryService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Category> _categorias = new(categoryService.GetAll());

    [ObservableProperty]
    private Category? _categoriaSeleccionada;

    [ObservableProperty]
    private int? _id = null;

    [ObservableProperty]
    private String? _nombre = String.Empty;

    [ObservableProperty]
    private String? _descripcion = String.Empty;

    private bool CanAddCategoria => (CategoriaSeleccionada == null && Id == null && !string.IsNullOrEmpty(Nombre) && !string.IsNullOrEmpty(Descripcion));

    public bool CanEditDeleteDeselectCategoria => CategoriaSeleccionada != null;

    partial void OnNombreChanged(string? value)
    {
        OnPropertyChanged(nameof(CanAddCategoria));
        AddCategoriaCommand.NotifyCanExecuteChanged();
    }

    partial void OnDescripcionChanged(string? value)
    {
        OnPropertyChanged(nameof(CanAddCategoria));
        AddCategoriaCommand.NotifyCanExecuteChanged();
    }

    partial void OnCategoriaSeleccionadaChanged(Category? selectedCategoria)
    {
        if (selectedCategoria != null)
        {
            Nombre = selectedCategoria.Nombre;
            Descripcion = selectedCategoria.Descripcion;
        }
        else
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }

        OnPropertyChanged(nameof(CanAddCategoria));
        AddCategoriaCommand.NotifyCanExecuteChanged();
        OnPropertyChanged(nameof(CanEditDeleteDeselectCategoria));
    }

    [RelayCommand(CanExecute = nameof(CanAddCategoria))]
    private void AddCategoria()
    {
        categoryService.Add(new Category
        {
            Nombre = Nombre,
            Descripcion = Descripcion
        });
        Categorias = new ObservableCollection<Category>(categoryService.GetAll());
        Nombre = String.Empty;
        Descripcion = String.Empty;
        Id = null;
    }

    [RelayCommand]
    private void DeleteCategoria()
    {
        categoryService.Delete(CategoriaSeleccionada);
        Categorias = new ObservableCollection<Category>(categoryService.GetAll());
    }

    [RelayCommand]
    private void UpdateCategoria()
    {
        Category categoria = CategoriaSeleccionada;
        categoria.Nombre = Nombre;
        categoria.Descripcion = Descripcion;
        categoryService.Update(categoria);
        Categorias = new ObservableCollection<Category>(categoryService.GetAll());
    }
}
