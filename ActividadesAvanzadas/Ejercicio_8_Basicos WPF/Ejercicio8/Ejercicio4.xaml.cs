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

namespace Ejercicio8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Ejercicio4 : Window
    {
        public Ejercicio4()
        {
            InitializeComponent();
        }
        private void BtnMostrarMensaje_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("¡Has hecho clic en el botón!", "Aviso");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}