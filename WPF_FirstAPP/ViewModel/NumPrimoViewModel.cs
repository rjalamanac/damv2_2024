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
using WPF_FirstAPP.Interfaces;

namespace WPF_FirstAPP.ViewModel
{
    public partial class NumPrimoViewModel : ViewModelBase
    {

        [ObservableProperty]
        public string _TxtBoxWPFText;

        [ObservableProperty]
        public string _LabelContent;

        private IPrimeNumberProvider _numberService;

        public NumPrimoViewModel(IPrimeNumberProvider numberService)
        {
            _numberService = numberService;
        }

        public override Task LoadAsync()
        {
            LabelContent = "Debes escribir un número";
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

            LabelContent = _numberService.IsNumberPrime(dato.Value) ? "El número es primo" : "El número no es primo";
        }
    }
}
