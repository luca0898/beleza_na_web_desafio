using BelezanaWeb.Product.Contracts.Services;
using BelezanaWeb.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BelezanaWeb.Registers.Contracts.Services
{
    public class RegistryServices
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
