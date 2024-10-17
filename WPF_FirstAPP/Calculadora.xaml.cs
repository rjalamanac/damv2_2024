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

namespace WPF_FirstAPP
{
    /// <summary>
    /// Lógica de interacción para Calculadora.xaml
    /// </summary>
    public partial class Calculadora : Window
    {
        private string? operador = null;
        public Calculadora()
        {
            InitializeComponent();
            foreach (var child in GridCalculadora.Children)
            {
                if (child is Button button)
                {
                    button.Click += Btn_Click;
                }

            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            
            if (sender is Button button && 
                button.Content is Viewbox view &&
                view.Child is TextBlock block)
            {
                

                switch (block.Text)
                {
                    case Constants.Mas:
                        CheckOperator(block.Text);
                        break;
                    case Constants.Menos:
                        CheckOperator(block.Text);
                        break;
                    case Constants.Division:
                        CheckOperator(block.Text);
                        break;
                    case Constants.Por:
                        CheckOperator(block.Text);
                        break;
                    case Constants.Resultado:
                        string resultado = GenerarResultado(block.Text);
                        if (string.IsNullOrEmpty(resultado))
                        {
                            return;
                        }
                        Txt_Calculadora.Text= resultado;
                        break;
                    case Constants.Pi:
                        if (string.IsNullOrEmpty(Txt_Calculadora.Text) || 
                                (!string.IsNullOrEmpty(operador) && 
                                !int.TryParse(Txt_Calculadora.Text.LastOrDefault().ToString(), out int valor)
                                ))
                        {
                            Txt_Calculadora.Text += block.Text;
                        }
                        break;
                   default:
                        if (Txt_Calculadora.Text.LastOrDefault().ToString()!=Constants.Pi)
                        {
                            Txt_Calculadora.Text += block.Text;
                        }
                        break;
                }
                
            }

        }

        private void CheckOperator(string blockText)
        {
            if (string.IsNullOrEmpty(Txt_Calculadora.Text) || !string.IsNullOrEmpty(operador))
            {
                return;
            }
            operador = blockText;
            Txt_Calculadora.Text += blockText;
        }

        private string GenerarResultado(string resultado)
        {
            if (string.IsNullOrEmpty(Txt_Calculadora.Text) ||
                                        string.IsNullOrEmpty(operador) ||
                                        (Txt_Calculadora.Text.LastOrDefault().ToString() == Constants.Pi) ||
                                        !int.TryParse(Txt_Calculadora.Text.LastOrDefault().ToString(), out int valor)
                                        )
            {
                return string.Empty;
            }
            string[] digitosOperacion = Txt_Calculadora.Text.Split(operador);
            decimal primerValor = GetDecimalValueFromString(digitosOperacion[0]);
            decimal segundoValor = GetDecimalValueFromString(digitosOperacion[2]);

            switch (operador)
            {
                case Constants.Mas:
                    operador = null;
                    return (primerValor + segundoValor).ToString();
                case Constants.Menos:
                    operador = null;
                    return (primerValor - segundoValor).ToString();
                case Constants.Division:
                    operador = null;
                    return segundoValor == decimal.Zero ? string.Empty : (primerValor / segundoValor).ToString();
                case Constants.Por:
                    operador = null;
                    return (primerValor * segundoValor).ToString();
                default:
                    return string.Empty;
            }
        }
        private decimal GetDecimalValueFromString(string digitosOperacion)
        {
            return digitosOperacion == Constants.Pi ? decimal.Parse(Math.PI.ToString()) : decimal.Parse(digitosOperacion);
        }
    }
}
