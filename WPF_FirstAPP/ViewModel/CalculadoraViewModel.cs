using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GestorDeTareas.Utils;
using PrimeritaConsola;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_FirstAPP.Interfaces;
using WPF_FirstAPP.Models;

namespace WPF_FirstAPP.ViewModel
{
    public partial class CalculadoraViewModel : ViewModelBase
    {

        private string? operador = null;

        [ObservableProperty]
        public string? _Txt_Calculadora;


        public CalculadoraViewModel()
        {
        }

        public override Task LoadAsync()
        {
            return base.LoadAsync();
        }

        [RelayCommand]
        public void Btn_Click(object? parameters)
        {
            string blockText = parameters?.ToString() ?? string.Empty;
            switch (blockText)
            {
                case Constants.Mas:
                    CheckOperator(blockText);
                    break;
                case Constants.Menos:
                    CheckOperator(blockText);
                    break;
                case Constants.Division:
                    CheckOperator(blockText);
                    break;
                case Constants.Por:
                    CheckOperator(blockText);
                    break;
                case Constants.Resultado:
                    string resultado = GenerarResultado(blockText);
                    if (string.IsNullOrEmpty(resultado))
                    {
                        return;
                    }
                    Txt_Calculadora = resultado;
                    break;
                case Constants.Pi:
                    if (string.IsNullOrEmpty(Txt_Calculadora) ||
                            (!string.IsNullOrEmpty(operador) &&
                            (int.TryParse(Txt_Calculadora.LastOrDefault().ToString(), out int valor) ||
                            Txt_Calculadora.LastOrDefault().ToString() != Constants.Pi)
                            ))
                    {
                        Txt_Calculadora += blockText;
                    }
                    break;
                default:
                    if (Txt_Calculadora?.LastOrDefault().ToString() != Constants.Pi)
                    {
                        Txt_Calculadora += blockText;
                    }
                    break;
            }
        }

        private void CheckOperator(string blockText)
        {

            if (string.IsNullOrEmpty(Txt_Calculadora) || !string.IsNullOrEmpty(operador))
            {
                return;
            }
            operador = blockText;
            Txt_Calculadora += blockText;
        }

        private string GenerarResultado(string resultado)
        {
            if (string.IsNullOrEmpty(Txt_Calculadora) || string.IsNullOrEmpty(operador))
            {
                return string.Empty;
            }

            if (!(Txt_Calculadora.LastOrDefault().ToString() == Constants.Pi) &&
                                        !int.TryParse(Txt_Calculadora.LastOrDefault().ToString(), out int valor))
            {
                return string.Empty;
            }

            string[] digitosOperacion = Txt_Calculadora.Split(operador);
            decimal primerValor = GetDecimalValueFromString(digitosOperacion[0]);
            decimal segundoValor = GetDecimalValueFromString(digitosOperacion[1]);

            switch (operador)
            {
                case Constants.Mas:
                    operador = null;
                    return (decimal.Round(primerValor + segundoValor, 4)).ToString();
                case Constants.Menos:
                    operador = null;
                    return (primerValor - segundoValor).ToString();
                case Constants.Division:
                    operador = null;
                    return segundoValor == decimal.Zero ? decimal.Zero.ToString() : (primerValor / segundoValor).ToString();
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
