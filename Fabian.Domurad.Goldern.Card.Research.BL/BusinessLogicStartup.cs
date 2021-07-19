using Fabian.Domurad.Golden.Card.Research.BL.Desk;
using Fabian.Domurad.Golden.Card.Research.BL.Desk.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.Floor;
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.Localization;
using Fabian.Domurad.Golden.Card.Research.BL.Localization.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.User;
using Fabian.Domurad.Golden.Card.Research.BL.User.Interface;
using Fabian.Domurad.Golden.Card.Research.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fabian.Domurad.Golden.Card.Research.BL
{
    public static class BusinessLogicStartup
    {
        public static void ConfigureBusinessLogicServices(this IServiceCollection services)
        {
            //Localization
            services.AddTransient<ILocalizationAddBusinessLogic, LocalizationAddBusinessLogic>();
            services.AddTransient<ILocalizationGetAllBusinessLogic, LocalizationGetAllBusinessLogic>();
            services.AddTransient<ILocalizationGetByIdBusinessLogic, LocalizationGetByIdBusinessLogic>();

            //Floor
            services.AddTransient<IFloorAddBusinessLogic, FloorAddBusinessLogic>();
            services.AddTransient<IFloorGetAllBusinessLogic, FloorGetAllBusinessLogic>();
            services.AddTransient<IFloorGetByIdBusinessLogic, FloorGetByIdBusinessLogic>();
            services.AddTransient<IFloorGetDesksBusinessLogic, FloorGetDesksBusinessLogic>();

            //User
            services.AddTransient<IUserCreateBusinessLogic, UserCreateBusinessLogic>();
            services.AddTransient<IUserAuthenticateBusinessLogic, UserAuthenticateBusinessLogic>();

            //Desk
            services.AddTransient<IDeskAddBusinessLogic, DeskAddBusinessLogic>();
            services.AddTransient<IDeskGetAllBusinessLogic, DeskGetAllBusinessLogic>();
            services.AddTransient<IDeskGetByIdBusinessLogic, DeskGetByIdBusinessLogic>();
            services.AddTransient<IDeskGetRoomBusinessLogic, DeskGetRoomBusinessLogic>();
        }

        public static void ConfigureDataServicesPass(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDataServices(configuration);
        }
    }
}
