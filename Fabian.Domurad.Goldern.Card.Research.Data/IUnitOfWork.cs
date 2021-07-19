using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.Data.Interface;

namespace Fabian.Domurad.Golden.Card.Research.Data
{
    public interface IUnitOfWork
    {
        public ILocalizationRepository Localization { get; }
        public IFloorRepository Floor { get; }
        public IDeskRepository Desk { get; }
        public IDeskBookingRepository DeskBooking { get; }
        public IUserRepository User { get; }
        Task SaveAsync();
    }
}
