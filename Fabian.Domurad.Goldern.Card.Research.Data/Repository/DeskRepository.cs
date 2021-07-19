using System.Linq;
using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Data.Interface;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Fabian.Domurad.Golden.Card.Research.Data.Repository
{
    public class DeskRepository : BaseRepository<DeskEntity, DeskDto>, IDeskRepository
    {
        public DeskRepository(GcResearchDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        protected override IQueryable<DeskEntity> Get => base.Get
            .Include(x => x.Floor)
            .ThenInclude(x => x.Localization)
            .Include(x => x.DeskBookings)
            .Include(x => x.Owner);
    }
}
