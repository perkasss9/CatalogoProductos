using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatalogoProductos.Views
{
    /// <summary>
    /// Lógica de interacción para AjustesView.xaml
    /// </summary>
    public partial class AjustesView : UserControl
    {
        public AjustesView()
        {
            InitializeComponent();
        }

        private void BotonEspanol_Click(object sender, RoutedEventArgs e)
        {
            ChangeLanguage("es");
        }

        private void BotonIngles_Click(object sender, RoutedEventArgs e)
        {
            ChangeLanguage("en");
        }

        private void ChangeLanguage(string cultureName)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);

            Properties.Settings.Default.Idioma = cultureName;
            Properties.Settings.Default.Save();

            MessageBox.Show("Por favor, reinicie la aplicación para aplicar los cambios de idioma.");
            Application.Current.Shutdown();
        }
    }
}
