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
    public partial class Ejercicio3 : Window
    {
        public Ejercicio3()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Se ha pulsado el botón.");
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Evento: Button.Click (Bubbling).\n" +
                "Comportamiento: El evento sube desde el botón hacia el contenedor StackPanel.");
        }
    }
}