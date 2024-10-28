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

namespace WPF_FirstAPP.ViewModel
{
    public partial class NumPrimoViewModel : ViewModelBase
    {

        [ObservableProperty]
        public string _TxtBoxWPFText;

        [ObservableProperty]
        public string _LabelContent;

        public override Task LoadAsync()
        {
            _LabelContent = "Debes escribir un número";
            return base.LoadAsync();
        }

        [RelayCommand]
        private  void Button_Click(object? parameter)
        {
            int? dato = StringUtils.ConvertToNumber(_TxtBoxWPFText);
            if (!dato.HasValue)
            {
                LabelContent = "Debes escribir un número";
                return;
            }

            LabelContent = Utils.IsNumberPrime(dato.Value) ? "El número es primo" : "El número no es primo";
        }
    }
}
