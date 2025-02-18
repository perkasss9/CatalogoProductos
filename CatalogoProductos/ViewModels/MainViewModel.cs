﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace CatalogoProductos.ViewModels;

partial class MainViewModel(
        HomeViewModel homeViewModel,
        ProductoViewModel productoViewModel,
        CategoriaViewModel categoriaViewModel,
        AjustesViewModel ajustesViewModel
    ) : ObservableObject
{
    [ObservableProperty]
    private object _activeView = homeViewModel;

    public HomeViewModel homeViewModel { get; } = homeViewModel;

    public CategoriaViewModel categoriaViewModel { get; } = categoriaViewModel;

    public ProductoViewModel productoViewModel { get; } = productoViewModel;

    public AjustesViewModel ajustesViewModel { get; } = ajustesViewModel;

    [RelayCommand]
    private void ActiveHomeView() => ActiveView = homeViewModel;

    [RelayCommand]
    private void ActiveCategoriaView() => ActiveView = categoriaViewModel;

    [RelayCommand]
    private void ActiveProductoView() => ActiveView = productoViewModel;

    [RelayCommand]
    private void ActiveAjustesView() => ActiveView = ajustesViewModel;

    [RelayCommand]
    private void CerrarApp()
    {
        Application.Current.Shutdown();
    }

}
