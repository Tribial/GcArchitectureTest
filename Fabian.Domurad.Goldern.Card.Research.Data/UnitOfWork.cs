using Fabian.Domurad.Golden.Card.Research.Data.Interface;
using System.Threading.Tasks;

namespace Fabian.Domurad.Golden.Card.Research.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GcResearchDbContext _dbContext;

        public UnitOfWork(GcResearchDbContext dbContext, ILocalizationRepository localizationRepository, IFloorRepository floorRepository,
            IDeskRepository deskRepository, IDeskBookingRepository deskBookingRepository,
            IUserRepository userRepository)
        {
            _dbContext = dbContext;
            Localization = localizationRepository;
            Floor = floorRepository;
            Desk = deskRepository;
            DeskBooking = deskBookingRepository;
            User = userRepository;
        }

        public ILocalizationRepository Localization { get; }

        public IFloorRepository Floor { get; }

        public IDeskRepository Desk { get; }

        public IDeskBookingRepository DeskBooking { get; }

        public IUserRepository User { get; }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
