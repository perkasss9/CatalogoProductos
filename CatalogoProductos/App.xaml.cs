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
            services.AddTransient<GraficoView>();


            services.AddTransient<MainViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<ProductoViewModel>();
            services.AddTransient<CategoriaViewModel>();
            services.AddTransient<AjustesViewModel>();
            services.AddTransient<GraficoViewModel>();


            services.AddSingleton<IRepository<Product>, ProductRepository>();
            services.AddSingleton<IRepository<Category>, CategoryRepository>();


            services.AddTransient<IRepositoryService<Product>, ProductService>();
            services.AddTransient<IRepositoryService<Category>, CategoryService>();


            services.AddDbContext<AppDbContext>(options =>
                    options.UseNpgsql("Host=localhost;Port=5432;Database=WpfAppDb;Username=postgres;Password=Interfaces-2425"));

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();

                if (!dbContext.Categories.Any())
                {
                    dbContext.Categories.Add(new Category { Nombre = "Sudaderas", Descripcion = "Categoría de sudaderas" });
                    dbContext.Categories.Add(new Category { Nombre = "Camisetas", Descripcion = "Categoría de camisetas" });
                    dbContext.Categories.Add(new Category { Nombre = "Pantalones", Descripcion = "Categoría de pantalones" });
                    dbContext.Categories.Add(new Category { Nombre = "Zapatos", Descripcion = "Categoría de zapatos" });
                    dbContext.SaveChanges();
                }

                if (!dbContext.Products.Any())
                {
                    dbContext.Products.Add(new Product { Nombre = "Sudadera Zara", Precio = 25.99, Descripcion = "Sudadera de Zara", IdCategoria = 1 });
                    dbContext.Products.Add(new Product { Nombre = "Sudadera Ralph Lauren", Precio = 250.00, Descripcion = "Sudadera de Ralph Lauren", IdCategoria = 1 });
                    dbContext.Products.Add(new Product { Nombre = "Camiseta Nike", Precio = 30.00, Descripcion = "Camiseta de Nike", IdCategoria = 2 });
                    dbContext.Products.Add(new Product { Nombre = "Pantalones Levis", Precio = 65.99, Descripcion = "Pantalones de Levis", IdCategoria = 3 });
                    dbContext.Products.Add(new Product { Nombre = "New Balance 550", Precio = 125.00, Descripcion = "Zapatillas de New Balance", IdCategoria = 4 });
                    dbContext.Products.Add(new Product { Nombre = "Nike Vapormax", Precio = 220.00, Descripcion = "Zapatillas de Nike", IdCategoria = 4 });
                    dbContext.SaveChanges();
                }
                dbContext.SaveChanges();
            }

            var view = serviceProvider.GetService<MainView>();
            view.DataContext = serviceProvider.GetService<MainViewModel>();
            view.Show();

        }
    }

}
