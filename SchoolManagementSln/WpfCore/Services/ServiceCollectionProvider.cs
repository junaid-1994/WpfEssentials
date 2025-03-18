using Microsoft.Extensions.DependencyInjection;

namespace WpfCore.Services
{
    /// <summary>
    /// A class for geting the instance of ServiceCollection.
    /// </summary>
    public class ServiceCollectionProvider
    {
        private static ServiceCollection _serviceCollection;

        private ServiceCollectionProvider()
        {
                
        }

        public static ServiceCollection GetServiceCollection()
        {
            if (_serviceCollection == null)
            {
                _serviceCollection = new ServiceCollection();
            }
            return _serviceCollection;
        }
    }
}
