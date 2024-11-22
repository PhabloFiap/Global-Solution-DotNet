using Global.Aplication.Services;
using Global.Domain.Interfaces;
using Global.Infrastructure.Data.AppData;
using Global.Infrastructure.Data.Repositories;

namespace Global.Infrastructure.IoC
{
    public class Bootstrap
    {
        public static void Start(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<ApplicationContext>(x => {
            //  x.UseOracle(configuration["ConnectionStrings:Oracle"]);
            // });

            services.AddTransient<IMoradorApplicationService, MoradorApplicationService>();

            services.AddTransient<IMoradorRepository, MoradorRepository>();


   

          

        }


    }
}
