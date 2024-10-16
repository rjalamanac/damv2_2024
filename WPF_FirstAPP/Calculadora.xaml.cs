﻿using GestorDeTareas.Utils;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_FirstAPP
{
    /// <summary>
    /// Lógica de interacción para Calculadora.xaml
    /// </summary>
    public partial class Calculadora : Window
    {
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
            
            if (sender is Button button)
            {
                var buttonSymbol = button.Name.Split("_").Last();
                Txt_Calculadora.Text += buttonSymbol;
            }

        }
    }
}
