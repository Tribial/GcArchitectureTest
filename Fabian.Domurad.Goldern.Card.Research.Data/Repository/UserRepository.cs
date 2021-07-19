using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Data.Interface;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace Fabian.Domurad.Golden.Card.Research.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity, UserDto>, IUserRepository
    {
        public UserRepository(GcResearchDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}
