using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Phoenicia.Infrastructures.Bootstrap
{
    public static class Bootstrapper
    {
        public static void Start(IServiceCollection services, params IServiceModule[] customModules)
        {
            if (customModules == null || !customModules.Any())
            {
                return;
            }

            foreach (IServiceModule customModule in customModules)
            {
                customModule.Load(services);
            }
        }
    }
}