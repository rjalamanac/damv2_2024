using CambioDivisa.Interfaces;
using CambioDivisa.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa.ViewModel
{
    public partial class CambioDivisaViewModel : ViewModelBase
    {
        private readonly ICambioDivisaService _cambioDivisa;
        private readonly IHistoricoDivisaProvider _historicoDivisa;

        public CambioDivisaViewModel(ICambioDivisaService cambioDivisa, IHistoricoDivisaProvider historicoDivisa)
        {
            _cambioDivisa = cambioDivisa;
            _historicoDivisa = historicoDivisa;
            _Amount = "0";
        }


        public ObservableCollection<string> Divisas { get; } = new();

        [ObservableProperty]
        public string _Amount;


        [ObservableProperty]
        public int _CB_Destination;


        [ObservableProperty]
        public int _CB_Origin;

        public override async Task LoadAsync()
        {
            if (Divisas.Any())
            {
                return;
            }

            var divisas = await _cambioDivisa.GetDivisas();
            if (divisas is not null)
            {
                foreach (var divisa in divisas)
                {
                    Divisas.Add(divisa);
                }
            }
        }

        [RelayCommand]
        private async Task CalcularDivisa(object? parameter)
        {
            if (string.IsNullOrEmpty(_Amount))
                return;

            decimal amount_origin = StringUtils.ConvertToDecimal(_Amount).Value;
            decimal amount_exchange = await _cambioDivisa.GetExchange(amount_origin, Divisas[CB_Origin], Divisas[CB_Destination]);

            _historicoDivisa.GuardarHistorico(amount_origin, amount_exchange, Divisas[CB_Origin], Divisas[CB_Destination]);
        }
    }
}
