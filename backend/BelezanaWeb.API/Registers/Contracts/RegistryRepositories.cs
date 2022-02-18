using BelezanaWeb.Db.NoSQL.Mongo.Repositories;
using BelezanaWeb.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BelezanaWeb.Registers.Contracts.Repositories
{
    public class RegistryRepositories
    {
        public static void Load(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
