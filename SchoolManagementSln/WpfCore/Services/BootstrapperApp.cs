using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WpfCore.Services
{
    /// <summary>
    /// A wrapper for Wpf Application which will extend the functionality.
    /// </summary>
    public class BootstrapperApp : Application
    {
        protected readonly IServiceCollection ServiceCollection;
        protected IServiceProvider ServiceProvider;

        public BootstrapperApp()
        {
            ServiceCollection = ServiceCollectionProvider.GetServiceCollection();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureServices(ServiceCollection);

            ServiceProvider = ServiceCollection.BuildServiceProvider();
            InitialiseShell();
        }

        private void InitialiseShell()
        {
            var shell = CreateShell();
            if(shell != null)
            {
                MainWindow = shell;
                MainWindow.Show();
            }
        }

        protected virtual Window CreateShell()
        {
            throw new NotImplementedException();
        }

        protected virtual void ConfigureServices(IServiceCollection iServiceCollection)
        {

        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            if (ServiceCollection is IDisposable service)
            {
                service.Dispose();
            }
        }
    }
}
