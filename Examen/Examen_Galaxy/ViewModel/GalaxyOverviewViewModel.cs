using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Examen_Galaxy.Constants;
using Examen_Galaxy.DTO;
using Examen_Galaxy.Interface;
using Examen_Galaxy.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Galaxy.ViewModel
{
    public partial  class GalaxyOverviewViewModel : ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<PlanetModel> _items;

        private readonly IHttpJsonProvider<PlanetaDTO> _httpJsonProvider;
        private ViewModelBase? _selectedViewModel;

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }

        public GalaxyOverviewViewModel(IHttpJsonProvider<PlanetaDTO> httpJsonProvider)
        {
            _httpJsonProvider = httpJsonProvider;
        }

        public override async Task LoadAsync()
        {
            IEnumerable<PlanetaDTO> planetas = await _httpJsonProvider.GetAsync(Constantes.PLANET_RESOURCE);
            Items = new ObservableCollection<PlanetModel>();
            foreach (var planeta in planetas)
            {
                Items.Add(PlanetModel.CreateModelFromDTO(planeta));
            }
        }

        [RelayCommand]
        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}
