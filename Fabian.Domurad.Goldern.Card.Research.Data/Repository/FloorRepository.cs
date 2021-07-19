using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Data.Interface;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fabian.Domurad.Golden.Card.Research.Data.Repository
{
    public class FloorRepository : BaseRepository<FloorEntity, FloorDto>, IFloorRepository
    {
        public FloorRepository(GcResearchDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        protected override IQueryable<FloorEntity> Get => base.Get.Include(x => x.Localization).Include(x => x.Desks);
    }
}
