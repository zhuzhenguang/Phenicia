using Microsoft.Extensions.DependencyInjection;

namespace Phoenicia.Infrastructures.Bootstrap
{
    public interface IServiceModule
    {
        void Load(IServiceCollection services);
    }
}