using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonBackRules.Model;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;


namespace PokemonBackRules.ViewModel
{
    public partial class PokeSukaViewModel : ViewModelBase
    {
        public ObservableCollection<string> PokeTypes { get; } = new();

        [ObservableProperty]
        public string _NumPokemons;

        public override async Task LoadAsync()
        {
            foreach (var element in nuestroModelo?.Results)
            {
                PokeTypes.Add(element.NombreType);
            }
        }


        [RelayCommand]
        private void Suka_Click(object? parameter)
        {
           
        }
    }
}
