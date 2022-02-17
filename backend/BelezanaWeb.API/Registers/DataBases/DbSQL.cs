using BelezanaWeb.Db.SQL;
using BelezanaWeb.SystemObjects;
using BelezanaWeb.SystemObjects.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BelezanaWeb.Registers.DataBases
{
    public class DbSQL
    {
        public static void Load(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    string connectionString = configuration.GetConnectionString("belezanaWebDbSqlConnectionString");
                    options.UseSqlServer(connectionString, o => o.MigrationsAssembly("BelezanaWeb.Repository.Db.SQL.Migrations"));
                });

            services
                .AddScoped<ApplicationDbContext>()
                .AddScoped<DbContext>((x) => x.GetService<ApplicationDbContext>())
                .AddScoped<IUnitOfWorkFactory<UnitOfWork>, UnitOfWorkFactory>();
        }
    }
}
