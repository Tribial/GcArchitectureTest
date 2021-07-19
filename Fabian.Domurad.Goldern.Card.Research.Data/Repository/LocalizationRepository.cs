using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Data.Interface;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Fabian.Domurad.Golden.Card.Research.Data.Repository
{
    public class LocalizationRepository : BaseRepository<LocalizationEntity, LocalizationDto>, ILocalizationRepository
    {
        public LocalizationRepository(GcResearchDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        protected override IQueryable<LocalizationEntity> Get => base.Get.Include(x => x.Floors);
    }
}
