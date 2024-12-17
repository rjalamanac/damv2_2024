using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Examen_Galaxy.Constants;
using Examen_Galaxy.DTO;
using Examen_Galaxy.Interface;
using Examen_Galaxy.Model;
using Examen_Galaxy.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Galaxy.ViewModel
{
    public partial class ExplorePlanetViewModel : ViewModelBase
    {
        [ObservableProperty]
        private ObservableCollection<PlanetModel> _items;
        private int _planetId;
        private GalaxyOverviewViewModel _galaxyOverviewViewModel;
        private readonly IHttpJsonProvider<PlanetaDTO> _httpJsonProvider;
        [ObservableProperty]
        private ExplorePlanetModel _Planet;

        public ExplorePlanetViewModel(IHttpJsonProvider<PlanetaDTO> httpJsonProvider)
        {
            _httpJsonProvider = httpJsonProvider;
            _items = new ObservableCollection<PlanetModel>();
        }

        public void SetIdPlanet(int id)
        {
            _planetId = id;
        }

        public override async Task LoadAsync()
        {
            IEnumerable<PlanetaDTO> planetas = await _httpJsonProvider.GetAsync(Constantes.PLANET_RESOURCE);
            Items = new ObservableCollection<PlanetModel>();
            foreach (var planeta in planetas)
            {
                Items.Add(PlanetModel.CreateModelFromDTO(planeta));
            }
            Planet = ExplorePlanetModel.CreateModelFromDTO(planetas.FirstOrDefault(x => x.Id == _planetId) ?? new PlanetaDTO());
        }

        internal void SetParentViewModel(ViewModelBase galaxyOverviewViewModel)
        {
            if (galaxyOverviewViewModel is GalaxyOverviewViewModel galaxyOverview)
            {
                _galaxyOverviewViewModel = galaxyOverview;
            }
        }

        [RelayCommand]
        private async Task Close(object? parameter)
        {
            if (_galaxyOverviewViewModel != null)
            {
                _galaxyOverviewViewModel.SelectedViewModel = null;
            }
        }
    }
}
