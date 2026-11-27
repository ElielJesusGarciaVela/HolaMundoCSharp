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
    public partial class Ejercicio5 : Window
    {
        public Ejercicio5()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Evento Button.Click - Un evento de acción directa");
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Evento MouseEnter - Detecta cuando el ratón entra en el botón");
        }

        private void Button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Evento Button_MouseRightButtonDown - Un evento de clic específico con el botón derecho");
        }
    }
}