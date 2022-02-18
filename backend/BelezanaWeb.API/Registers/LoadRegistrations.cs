using BelezanaWeb.Registers.Contracts.Repositories;
using BelezanaWeb.Registers.Contracts.Services;
using BelezanaWeb.Registers.DataBases;
using BelezanaWeb.Registers.Mapping;
using BelezanaWeb.Registers.Swagger;
using BelezanaWeb.Registers.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace BelezanaWeb.Registers
{
    public static class LoadRegistrations
    {
        public static void ConfigureContainers(IServiceCollection services)
        {
            LoadValidators.Load(services);
            MongoDBRegister.Load(services);
            SwaggerRegister.Load(services);
            AutoMapperLoadProfiles.Load(services);
            RegistryServices.Load(services);
            RegistryRepositories.Load(services);
        }
    }
}
