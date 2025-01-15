using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Wpf.Ui.Abstractions.Controls;
using Wpf.Ui.Demo.Mvvm.ViewModels;

namespace WPF_UI.Views.Pages
{
    public partial class BasePage<TViewModel> : Page, INavigableView<TViewModel>
        where TViewModel : class
    {
        public TViewModel ViewModel { get; }

        public BasePage(TViewModel viewModel) : base()
        {
            ViewModel = viewModel;
            DataContext = viewModel;

            // Attach Loaded event
            Loaded += OnPageLoaded;
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            if (ViewModel is ViewModel viewModelWithNavigation)
            {
                viewModelWithNavigation.OnNavigatedToAsync();
            }
        }
    }
}
