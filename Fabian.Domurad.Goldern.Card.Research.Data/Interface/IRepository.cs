using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;

namespace Fabian.Domurad.Golden.Card.Research.Data.Interface
{
    public interface IRepository<TDto> where TDto : BaseDto
    {
        Task<Guid> AddAsync(TDto dto);
        Task<Guid> UpdateAsync(TDto dto);
        Task Delete(TDto dto);
        Task<bool> ExistsAsync(Expression<Func<TDto, bool>> expression);
        IQueryable<TDto> GetAll();
        Task<TDto> GetByIdAsync(Guid id);
    }
}
