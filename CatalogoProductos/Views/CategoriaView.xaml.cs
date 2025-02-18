using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para CategoriaView.xaml
    /// </summary>
    public partial class CategoriaView : UserControl
    {
        public CategoriaView()
        {
            InitializeComponent();
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject clickedElement = e.OriginalSource as DependencyObject;

            while (clickedElement != null)
            {
                if (clickedElement is TextBox || clickedElement is Button)
                {
                    return;
                }
                clickedElement = VisualTreeHelper.GetParent(clickedElement);
            }

            if (!miListView.IsMouseOver)
            {
                miListView.SelectedItem = null;
            }
        }
    }
}
