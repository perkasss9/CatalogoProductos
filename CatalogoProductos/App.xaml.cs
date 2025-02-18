using CatalogoProductos.Data;
using CatalogoProductos.Models;
using CatalogoProductos.Repositories;
using CatalogoProductos.Services;
using CatalogoProductos.ViewModels;
using CatalogoProductos.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Windows;

namespace CatalogoProductos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string idioma = CatalogoProductos.Properties.Settings.Default.Idioma;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(idioma);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(idioma);

            ServiceCollection services = new();

            services.AddSingleton<MainView>();
            services.AddTransient<HomeView>();
            services.AddTransient<ProductoView>();
            services.AddTransient<CategoriaView>();
            services.AddTransient<AjustesView>();


            services.AddTransient<MainViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<ProductoViewModel>();
            services.AddTransient<CategoriaViewModel>();
            services.AddTransient<AjustesViewModel>();


            services.AddSingleton<IRepository<Product>, ProductRepository>();
            services.AddSingleton<IRepository<Category>, CategoryRepository>();


            services.AddTransient<IRepositoryService<Product>, ProductService>();
            services.AddTransient<IRepositoryService<Category>, CategoryService>();


            services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql("Host=localhost;Port=5432;Database=WpfAppDb;Username=postgres;Password=Interfaces-2425"));

            var serviceProvider = services.BuildServiceProvider();

            var view = serviceProvider.GetService<MainView>();
            view.DataContext = serviceProvider.GetService<MainViewModel>();
            view.Show();

        }
    }

}
