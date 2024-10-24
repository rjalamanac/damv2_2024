using CambioDivisa.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa.ViewModel
{
    public class HistoricoCambioDivisaViewModel : ViewModelBase
    {
        private readonly IHistoricoDivisaProvider _historicoDivisaProvider;

        public HistoricoCambioDivisaViewModel(IHistoricoDivisaProvider historicoDivisa)
        {
            _historicoDivisaProvider = historicoDivisa;
        }

        public ObservableCollection<string> Historico { get; } = new();

        public override async Task LoadAsync()
        {
            var historico = await _historicoDivisaProvider.GetHistorico();
            if (Historico is not null)
            {
                Historico.Clear();
                foreach (var stats in historico)
                {
                    Historico.Add(stats);
                }
            }
        }
    }
}
