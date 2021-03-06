using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BelezanaWeb.Registers.Mapping
{
    public class AutoMapperLoadProfiles
    {
        public static void Load(IServiceCollection services)
        {
            var x = new MapperConfiguration(config =>
            {
                config.AllowNullDestinationValues = true;
                config.AllowNullCollections = true;

                // Adding each profile
                config.AddProfile<InventoryProfile>();
                config.AddProfile<ProductProfile>();
                config.AddProfile<WarehouseProfile>();
                // ...
            }).CreateMapper();

            services.AddSingleton(register => x);
        }
    }
}
