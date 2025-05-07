using Microsoft.Extensions.DependencyInjection;
using Quzz_rozwiazywanie.Services;
using Quzz_rozwiazywanie.ViewModels;
using Quzz_rozwiazywanie.Views;
using System.Windows;

namespace Quzz_rozwiazywanie
{
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<FileService>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<QuizSolverViewModel>();
            services.AddSingleton<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}