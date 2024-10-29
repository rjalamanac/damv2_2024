using CambioDivisa.Interfaces;
using CambioDivisa.Service;
using CambioDivisa.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace CambioDivisa
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = Current.Services.GetService<MainWindow>();
            mainWindow?.Show();
        }
        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //view principal
            services.AddTransient<MainWindow>();

            //view viewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<CambioDivisaViewModel>();
            services.AddTransient<HistoricoCambioDivisaViewModel>();

            //Services
            services.AddSingleton<ICambioDivisaService, CambioDivisaService>();
            services.AddSingleton<IHistoricoDivisaProvider, HistoricoDivisaService>();
            return services.BuildServiceProvider();
        }
    }

}
