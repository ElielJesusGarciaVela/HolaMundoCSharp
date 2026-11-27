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

namespace Ejercicio9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Ejercicio9Window : Window
    {
        public Ejercicio9Window()
        {
            InitializeComponent();
        }
        private void BtnContacto_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Email: elieljesusgarciavela@2dam.es\nTeléfono: 600 000 000", "Contacto");
        }
    }
}