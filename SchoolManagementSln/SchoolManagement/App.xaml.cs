using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.View;
using System.Windows;
using WpfCore.Services;

namespace SchoolManagement;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : BootstrapperApp
{
    protected override void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton(typeof(ShellView));
    }

    protected override Window CreateShell()
    {
        return ServiceProvider.GetRequiredService<ShellView>();
    }

}

