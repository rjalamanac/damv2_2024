﻿using CommunityToolkit.Mvvm.Input;
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

        public MainViewModel(NumPrimoViewModel numPrimoViewModel, CalculadoraViewModel calculadoraViewModel,
            StackExampleViewModel stackExampleViewModel, ContactManagerViewModel contactManagerViewModel)
        {
            _selectedViewModel = contactManagerViewModel;
            StackExampleViewModel = stackExampleViewModel;
            NumPrimoViewModel = numPrimoViewModel;
            CalculadoraViewModel = calculadoraViewModel;
            ContactManagerViewModel = contactManagerViewModel;
        }

        public NumPrimoViewModel NumPrimoViewModel { get; }
        public CalculadoraViewModel CalculadoraViewModel { get; }
        public StackExampleViewModel StackExampleViewModel { get; }
        public ContactManagerViewModel ContactManagerViewModel { get; }

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
