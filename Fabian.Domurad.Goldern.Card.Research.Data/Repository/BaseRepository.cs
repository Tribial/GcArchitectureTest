using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Fabian.Domurad.Golden.Card.Research.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace Fabian.Domurad.Golden.Card.Research.Data.Repository
{
    public abstract class BaseRepository<TEntity, TDto> 
        where TEntity : BaseEntity 
        where TDto : BaseDto
    {
        private readonly GcResearchDbContext _db;
        private readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper Mapper;

        protected BaseRepository(GcResearchDbContext db, IMapper mapper)
        {
            _db = db;
            Mapper = mapper;
            _dbSet = db.Set<TEntity>();
        }

        public async Task<Guid> AddAsync(TDto dto)
        {
            var entity = Mapper.Map<TEntity>(dto);
            
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = SystemTime.UtcNow;

            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<Guid> UpdateAsync(TDto dto)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
            {
                throw new BusinessLogicException(ErrorMessageConst.EntityNotFound, ExceptionType.NotFound);
            }
            var updated = Mapper.Map(dto, entity);
            updated.ModifiedAt = SystemTime.UtcNow;

            return updated.Id;
        }

        public async Task Delete(TDto dto)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(x => x.Id == dto.Id);
            _dbSet.Remove(entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<TDto, bool>> expression)
        {
            return await GetAll().AnyAsync(expression);
        }

        public IQueryable<TDto> GetAll()
        {
            return Mapper.ProjectTo<TDto>(Get);
        }

        public async Task<TDto> GetByIdAsync(Guid id)
        {
            var entity = await Get.FirstOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<TDto>(entity ?? throw new BusinessLogicException(ErrorMessageConst.EntityNotFound, ExceptionType.NotFound));
        }

        protected virtual IQueryable<TEntity> Get => _dbSet.AsQueryable();
    }
}
