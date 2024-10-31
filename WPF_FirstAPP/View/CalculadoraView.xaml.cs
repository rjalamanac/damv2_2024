using GestorDeTareas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_FirstAPP.Models;
using WPF_FirstAPP.ViewModel;

namespace WPF_FirstAPP.View
{
    /// <summary>
    /// Lógica de interacción para Calculadora.xaml
    /// </summary>
    public partial class CalculadoraView : UserControl
    {
        public CalculadoraView(CalculadoraViewModel calculadoraViewModel)
        {
            DataContext = calculadoraViewModel;
            InitializeComponent();
            foreach (var child in GridCalculadora.Children)
            {
                if (child is Button button)
                {
                    button.Command = calculadoraViewModel.Btn_ClickCommand;
                }
            }
        }
    }
}
