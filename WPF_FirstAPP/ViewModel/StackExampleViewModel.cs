using System.Collections.ObjectModel;
using WPF_FirstAPP.Models;
using WPF_FirstAPP.Utils;


namespace WPF_FirstAPP.ViewModel
{
    public partial class StackExampleViewModel : ViewModelBase
    {

        private static readonly Random Random = new();

        public ObservableCollection<StackPanelItemModel> Items { get; set; }

        public StackExampleViewModel()
        {
            Items = new ObservableCollection<StackPanelItemModel>();
        }

        private void GenerateRandomItems()
        {
            int itemCount = Random.Next(Constants.MIN_NUMBER_ITEMS_STACK_PANEL, Constants.MAX_NUMBER_ITEMS_STACK_PANEL);
            for (int i = 0; i < itemCount; i++)
            {
                Items.Add(new StackPanelItemModel
                {
                    ImagePath = Constants.HALLOWEEN_URL_PATH,
                    BackgroundColor = GetRandomColor(),
                    TextColor = GetRandomColor(),
                    Text = $"Item {i + 1}"
                });
            }
        }

        private string GetRandomColor()
        {
            return $"#{Random.Next(0x1000000):X6}";
        }

        public override Task LoadAsync()
        {
            GenerateRandomItems();
            return base.LoadAsync();
        }
    }
}
