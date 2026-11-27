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
    public partial class Ejercicio2 : Window
    {
        public Ejercicio2()
        {
            InitializeComponent();

            Grid grid = new Grid();

            Button boton = new Button
            {
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Padding = new Thickness(10)
            };

            WrapPanel wrapPanel = new WrapPanel();

            TextBlock tb1 = new TextBlock { Text = "Texto Verde ", Foreground = Brushes.Green };
            TextBlock tb2 = new TextBlock { Text = "Texto Azul ", Foreground = Brushes.Blue };
            TextBlock tb3 = new TextBlock { Text = "Texto Sin Formato" };

            wrapPanel.Children.Add(tb1);
            wrapPanel.Children.Add(tb2);
            wrapPanel.Children.Add(tb3);

            boton.Content = wrapPanel;
            grid.Children.Add(boton);
            this.Content = grid;
        }
    }
}