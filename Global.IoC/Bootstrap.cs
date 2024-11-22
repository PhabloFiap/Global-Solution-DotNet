
using Global.Application.Services;
using Global.Data.Repositories;
using Global.Domain.Interfaces;
using Global.Infrastructure.Data.AppData;
using Global.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Global.Infrastructure.IoC
{
    public class Bootstrap
    {



        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(x => {
              x.UseOracle(configuration["ConnectionStrings:Oracle"]);
             });

            services.AddTransient<IMoradorApplicationService, MoradorApplicationService>();

            services.AddTransient<IMoradorRepository, MoradorRepository>();

            services.AddTransient<IMedidorApplicationService, MedidorApplicationService>();

            services.AddTransient<IMedidorRepository, MedidorRepository>();
          


   

          

        }


    }
}
