using Fabian.Domurad.Golden.Card.Research.Data.Interface;
using Fabian.Domurad.Golden.Card.Research.Data.Repository;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fabian.Domurad.Golden.Card.Research.Data
{
    public static class DataStartup
    {
        public static void ConfigureDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GcResearchDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString(configuration[DataConst.UseDbConnectionsString])));

            services.AddTransient<ILocalizationRepository, LocalizationRepository>();
            services.AddTransient<IFloorRepository, FloorRepository>();
            services.AddTransient<IDeskRepository, DeskRepository>();
            services.AddTransient<IDeskBookingRepository, DeskBookingRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
