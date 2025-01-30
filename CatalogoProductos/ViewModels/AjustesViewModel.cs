using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Globalization;
using System.Windows;

namespace CatalogoProductos.ViewModels;

public partial class AjustesViewModel : ObservableObject 
{
    [RelayCommand]
    private void CambiarEsp() => CambiarIdioma("es");

    [RelayCommand]
    private void CambiarEng() => CambiarIdioma("en");

    private void CambiarIdioma(string idioma)
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(idioma);

        Properties.Settings.Default.Idioma = idioma;
        Properties.Settings.Default.Save();

        MessageBox.Show("Por favor, reinicie la aplicación para aplicar los cambios de idioma.");
        Application.Current.Shutdown();
    }
}
