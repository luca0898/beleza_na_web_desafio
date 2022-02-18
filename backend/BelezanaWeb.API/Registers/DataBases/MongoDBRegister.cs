using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace BelezanaWeb.Registers.DataBases
{
    public static class MongoDBRegister
    {
        public static void Load(IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>((imp) =>
            {
                var config = imp.GetService<IConfiguration>();

                string connectionString = config.GetConnectionString("MongoDB");

                return new MongoClient(connectionString);
            });

            services.AddSingleton((imp) =>
            {
                var config = imp.GetService<IConfiguration>();

                string databaseName = config.GetSection("MongoDB:DatabaseName").Value;

                IMongoClient mongoClient = imp.GetService<IMongoClient>();

                return mongoClient.GetDatabase(databaseName);
            });
        }
    }
}
