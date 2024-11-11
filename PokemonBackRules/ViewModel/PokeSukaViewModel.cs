using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonBackRules.Model;
using PokemonBackRules.Utils;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text.Json;


namespace PokemonBackRules.ViewModel
{
    public partial class PokeSukaViewModel : ViewModelBase
    {

        private static readonly Random _random = new();
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
            if (PokemonType>=0 || PokemonType<= PokeTypes.Count-1 && StringUtils.ConvertToNumber(NumPokemons)!=null)
            {
                string tipo = PokeTypes[PokemonType];
      
                PokemonsByTypeModel pokemonsByType = await HttpJsonClient<PokemonsByTypeModel>.Get($"{ Constantes.POKE_TYPE_URL}/{ tipo}") 
                    ?? new PokemonsByTypeModel();

                int indexStartShowPokemon = _random.Next(0, pokemonsByType.pokemon.Count - 2);

                List<Task<PokemonSpriteModel>> peticionesSprite = new List<Task<PokemonSpriteModel>>();

                for (int i = indexStartShowPokemon; i < pokemonsByType.pokemon.Count - 1 &&
                    peticionesSprite.Count<= Constantes.MAX_POKE_ITEMS; i++)
                {
                    peticionesSprite.Add(HttpJsonClient<PokemonSpriteModel>.Get(pokemonsByType.pokemon[i].pokemon.url));                    
                }
                await Task.WhenAll(peticionesSprite);                

                PokemonSpriteModel sprite;
                foreach (var pokemonSprite in peticionesSprite)
                {
                    sprite = await pokemonSprite;

                }

            }
        }
    }
}
