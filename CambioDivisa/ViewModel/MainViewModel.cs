using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CambioDivisa.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public MainViewModel(CambioDivisaViewModel cambioDivisa, HistoricoCambioDivisaViewModel historicoCambio)
        {
            CambioDivisaViewModel = cambioDivisa;
            HistoricoCambioDivisaViewModel = historicoCambio;
            SelectedViewModel = cambioDivisa;
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }
        public CambioDivisaViewModel CambioDivisaViewModel { get; }
        public HistoricoCambioDivisaViewModel HistoricoCambioDivisaViewModel { get; }

        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        [RelayCommand]
        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }

        [RelayCommand]
        private void ExitApplication(object? obj)
        {
            Application.Current.Shutdown();
        }

    }
}
