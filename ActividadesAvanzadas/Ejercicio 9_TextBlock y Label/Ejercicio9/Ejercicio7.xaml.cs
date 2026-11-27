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
    public partial class Ejercicio7 : Window
    {
        public Ejercicio7()
        {
            InitializeComponent();
        }
        //OPCION 1
        private void BtnExcepcion_Click(object sender, RoutedEventArgs e)
        {
            int[] numeros = new int[3];
            numeros[5] = 10;
        }
        //OPCION 2
        //private void BtnExcepcion_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        int[] numeros = new int[3];
        //        numeros[5] = 10;
        //    }
        //    catch (IndexOutOfRangeException ex)
        //    {
        //        MessageBox.Show($"Error capturado: {ex.Message}", "Excepción controlada",
        //                        MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
    }
}