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


        private ObservableCollection<StackPanelItemModel> _items;

        public ObservableCollection<StackPanelItemModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public StackExampleViewModel(ILibrosProvider librosProvider)
        {
            _librosProvider = librosProvider;
        }


        private async Task GenerateRandomItemsAsync()
        {
            Items = new ObservableCollection<StackPanelItemModel>();

            List<LibroDTO> listaLibros =await _librosProvider.GetAsync();

            foreach(var libro in listaLibros)
            {
                Items.Add(StackPanelItemModel.CreateModelFromDTO(libro));
            }
        }

        public override async Task LoadAsync()
        {
            await GenerateRandomItemsAsync();
            base.LoadAsync();
        }
    }
}
