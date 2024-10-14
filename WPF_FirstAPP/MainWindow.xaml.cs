using GestorDeTareas.Utils;
using PrimeritaConsola;
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

namespace WPF_FirstAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtBoxWPF.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int? dato=StringUtils.ConvertToNumber(txtBoxWPF.Text);
            if (!dato.HasValue)
            {
                LabelFirstWPF.Content = "Debes escribir un número";
                return;
            }

            LabelFirstWPF.Content = Utils.IsNumberPrime(dato.Value) ? "El número es primo" : "El número no es primo";
        }
    }
}