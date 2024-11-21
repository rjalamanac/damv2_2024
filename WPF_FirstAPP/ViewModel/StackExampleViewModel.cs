using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_FirstAPP.DTO;
using WPF_FirstAPP.Interfaces;
using WPF_FirstAPP.Models;
using WPF_FirstAPP.Utils;


namespace WPF_FirstAPP.ViewModel
{
    public partial class StackExampleViewModel : ViewModelBase
    {

        private readonly ILibrosProvider _librosProvider;

        public ObservableCollection<StackPanelItemModel> Items { get; set; }

        public StackExampleViewModel(ILibrosProvider librosProvider)
        {
            _librosProvider = librosProvider;
        }

        public StackExampleViewModel()
        {
        }

        private async Task GenerateRandomItemsAsync()
        {
            Items = [];

            List<LibroDTO> listaLibros =await _librosProvider.GetAsync();

            foreach(var libro in listaLibros)
            {
                Items.Add(new StackPanelItemModel
                {
                    ImagePath = Constants.HALLOWEEN_URL_PATH,
                    Text = $"{libro.Titulo}: {libro.NumPaginas}"
                });
            }
        }

        public override async Task LoadAsync()
        {
            await GenerateRandomItemsAsync();
            base.LoadAsync();
        }
    }
}
