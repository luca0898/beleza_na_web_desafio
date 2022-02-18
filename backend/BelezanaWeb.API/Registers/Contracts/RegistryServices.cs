using BelezanaWeb.Domain.Contracts.Services;
using BelezanaWeb.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BelezanaWeb.Registers.Contracts.Services
{
    public class RegistryServices
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
