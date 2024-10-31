using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_FirstAPP.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public MainViewModel(NumPrimoViewModel numPrimoViewModel, CalculadoraViewModel calculadoraViewModel)
        {
            _selectedViewModel = calculadoraViewModel;
            NumPrimoViewModel = numPrimoViewModel;
            CalculadoraViewModel = calculadoraViewModel;
        }

        public NumPrimoViewModel NumPrimoViewModel { get; }
        public CalculadoraViewModel CalculadoraViewModel { get; }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }

        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
    }
}
