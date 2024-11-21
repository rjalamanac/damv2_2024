using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WPF_FirstAPP.Interfaces;
using WPF_FirstAPP.Services;
using WPF_FirstAPP.ViewModel;

namespace WPF_FirstAPP
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
            services.AddTransient<NumPrimoViewModel>();
            services.AddTransient<CalculadoraViewModel>();
            services.AddTransient<StackExampleViewModel>();

            //Services
            services.AddSingleton<IPrimeNumberProvider, PrimeNumberService>();
            services.AddSingleton<ILibrosProvider, LibrosApiService>();        
            return services.BuildServiceProvider();
        }
    }

}
