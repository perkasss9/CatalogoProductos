using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatalogoProductos.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        LoadSettings();
        InitializeComponent();
    }

    private void LoadSettings()
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.Idioma);
    }

    private void cerrarSesion_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}