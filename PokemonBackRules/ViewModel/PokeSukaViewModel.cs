using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonBackRules.Model;
using PokemonBackRules.Utils;
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

        [ObservableProperty]
        public int _PokemonType;

        public override async Task LoadAsync()
        {
            PokeTypesModel requestData =await HttpJsonClient<PokeTypesModel>.Get(Constantes.POKE_TYPE_URL) ?? new PokeTypesModel();
            foreach (var element in requestData.Results)
            {
                PokeTypes.Add(element.NombreType);
            }
        }


        [RelayCommand]
        private async Task Suka_Click(object? parameter)
        {
            if (PokemonType>=0 || PokemonType<= PokeTypes.Count-1)
            {
                string tipo = PokeTypes[PokemonType];
                PokemonsByTypeModel requestData = await HttpJsonClient<PokemonsByTypeModel>.Get($"{ Constantes.POKE_TYPE_URL}/{ tipo}") 
                    ?? new PokemonsByTypeModel();
            }
        }
    }
}
