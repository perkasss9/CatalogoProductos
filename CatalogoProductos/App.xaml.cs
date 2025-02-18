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

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();

                if (!dbContext.Categories.Any())
                {
                    dbContext.Categories.Add(new Category { Nombre = "Zapatos", Descripcion = "Categoría de zapatos" });
                    dbContext.Categories.Add(new Category { Nombre = "Abrigos", Descripcion = "Categoría de abrigos" });
                    dbContext.Categories.Add(new Category { Nombre = "Pantalones", Descripcion = "Categoría de pantalones" });
                    dbContext.Categories.Add(new Category { Nombre = "Camisetas", Descripcion = "Categoría de camisetas" });
                    dbContext.Categories.Add(new Category { Nombre = "Calcetines", Descripcion = "Categoría de calcetines" });
                    dbContext.SaveChanges();
                }

                if (!dbContext.Products.Any())
                {
                    dbContext.Products.Add(new Product { Nombre = "Nike Air Jordan 1 Low", Precio = 149.99, Descripcion = "Zapatillas Air Jordan 1 Low", IdCategoria = 1 });
                    dbContext.Products.Add(new Product { Nombre = "Adidas Campus", Precio = 125.99, Descripcion = "Zapatillas Campus de Adidas", IdCategoria = 1 });
                    dbContext.Products.Add(new Product { Nombre = "Abrigo North Face", Precio = 99.99, Descripcion = "Abrigo de la marca North Face", IdCategoria = 2 });
                    dbContext.Products.Add(new Product { Nombre = "Pantalones Adidas", Precio = 49.99, Descripcion = "Pantalones de la marca Adidas", IdCategoria = 3 });
                    dbContext.Products.Add(new Product { Nombre = "Camiseta Amiri", Precio = 79.99, Descripcion = "Camiseta de la marca Amiri", IdCategoria = 4 });
                    dbContext.Products.Add(new Product { Nombre = "Pantalones Nike", Precio = 45.99, Descripcion = "pantalones de la marca Nike", IdCategoria = 3 });
                    dbContext.Products.Add(new Product { Nombre = "Abrigo Puma", Precio = 85.00, Descripcion = "Abrigo de la marca Puma", IdCategoria = 2 });
                    dbContext.Products.Add(new Product { Nombre = "Calcetines Jordan", Precio = 9.99, Descripcion = "Calcetines de la marca Jordan", IdCategoria = 5 });
                    dbContext.Products.Add(new Product { Nombre = "Calcetines Primark", Precio = 4.99, Descripcion = "Calcetines del Primark", IdCategoria = 5 });
                    dbContext.Products.Add(new Product { Nombre = "Camiseta Puma", Precio = 29.99, Descripcion = "Camiseta de la marca Puma", IdCategoria = 4 });
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
