using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CatalogoProductos.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private object _activeView;

    public HomeViewModel homeViewModel { get; } = new HomeViewModel();

    public CategoriaViewModel categoriaViewModel { get; } = new CategoriaViewModel();

    public ProductoViewModel productoViewModel { get; } = new ProductoViewModel();

    public AjustesViewModel ajustesViewModel { get; } = new AjustesViewModel();

    public MainViewModel() => ActiveView = homeViewModel;

    [RelayCommand]
    private void ActiveHomeView() => ActiveView = homeViewModel;

    [RelayCommand]
    private void ActiveCategoriaView() => ActiveView = categoriaViewModel;

    [RelayCommand]
    private void ActiveProductoView() => ActiveView = productoViewModel;

    [RelayCommand]
    private void ActiveAjustesView() => ActiveView = ajustesViewModel;  

}
