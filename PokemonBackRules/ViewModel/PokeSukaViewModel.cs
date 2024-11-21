using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PokemonBackRules.Model;
using PokemonBackRules.Models;
using PokemonBackRules.Utils;
using System.Collections.ObjectModel;


namespace PokemonBackRules.ViewModel
{
    public partial class PokeSukaViewModel : ViewModelBase
    {

        private static readonly Random _random = new();
        public ObservableCollection<StackPanelItemModel> Items { get; set; }
        public ObservableCollection<string> PokeTypes { get; } = new();

        [ObservableProperty]
        public string _NumPokemons;

        [ObservableProperty]
        public int _PokemonType;

        public PokeSukaViewModel()
        {
            Items = new ObservableCollection<StackPanelItemModel>();
        }

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
            Items.Clear();
            int numPokemonsGrid = StringUtils.ConvertToNumber(NumPokemons) ?? int.MaxValue;
            if (PokemonType>=0 && PokemonType<= PokeTypes.Count-1 
                && StringUtils.ConvertToNumber(NumPokemons)!=null
                && numPokemonsGrid <= Constantes.MAX_POKE_ITEMS)
            {
                string tipo = PokeTypes[PokemonType];

                PokemonsByTypeModel pokemonsByType = await HttpJsonClient<PokemonsByTypeModel>.Get($"{Constantes.POKE_TYPE_URL}/{tipo}")
                    ?? new PokemonsByTypeModel();

                int indexStartShowPokemon = _random.Next(0, pokemonsByType.pokemon.Count - 2);

                List<Task<PokemonSpriteModel>> peticionesSprite = new List<Task<PokemonSpriteModel>>();

                for (int i = indexStartShowPokemon; i < pokemonsByType.pokemon.Count - 1 &&
                    peticionesSprite.Count < numPokemonsGrid; i++)
                {
                    peticionesSprite.Add(HttpJsonClient<PokemonSpriteModel>.Get(pokemonsByType.pokemon[i].pokemon.url));
                }
                await Task.WhenAll(peticionesSprite);

                await GenerateStackPanelItems(pokemonsByType, indexStartShowPokemon, peticionesSprite, numPokemonsGrid);
            }
        }

        private async Task GenerateStackPanelItems(PokemonsByTypeModel pokemonsByType, int indexStartShowPokemon,
            List<Task<PokemonSpriteModel>> peticionesSprite, int numPokemonsGrid)
        {
            int contador = 0;
            PokemonSpriteModel sprite;
            for (int i = indexStartShowPokemon; i < pokemonsByType.pokemon.Count - 1 &&
               contador < numPokemonsGrid; i++)
            {
                sprite = await peticionesSprite[contador];
                contador++;
                Items.Add(new StackPanelItemModel
                {
                    ImagePath = sprite.sprites.back_default ?? Constantes.MISSINGNO_IMAGE_PATH,
                    PokemonName = pokemonsByType.pokemon[i].pokemon.name
                });
            }
        }
    }
}
