using CatalogoProductos.Models;
using CatalogoProductos.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CatalogoProductos.ViewModels;

public partial class GraficoViewModel(IRepositoryService<Category> categoryService, IRepositoryService<Product> productService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Product> _productos;

    [ObservableProperty]
    private ObservableCollection<Category> _categorias;

    public PlotModel ProductosPorCategoriaGrafico { get; set; }

    [RelayCommand]
    private void RecargarGraficos()
    {
        _productos = new ObservableCollection<Product>(productService.GetAll());
        _categorias = new ObservableCollection<Category>(categoryService.GetAll());
        ConfigurarProductosPorCategoria();
    }

    private void ConfigurarProductosPorCategoria()
    {
        ProductosPorCategoriaGrafico = new PlotModel
        {
            Padding = new OxyThickness(50)
        };

        var pieSeries = new PieSeries
        {
            AngleSpan = 360,
            StartAngle = 0
        };

        var productosAgrupados = _productos.GroupBy(l => l.IdCategoria).Select(group => new { Type = group.Key, Count = group.Count() });

        foreach (var grupo in productosAgrupados)
        {
            var categoria = grupo.Type.HasValue ? categoryService.Get(grupo.Type.Value) : null;
            pieSeries.Slices.Add(new PieSlice(categoria?.Nombre ?? "Desconocido", grupo.Count));
        }

        ProductosPorCategoriaGrafico.Series.Add(pieSeries);
    }
}
