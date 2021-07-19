using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.Desk.Interface;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Fabian.Domurad.Golden.Card.Research.BL.Desk
{
    public class DeskGetAllBusinessLogic : BaseBusinessLogic<IEnumerable<DeskDto>, IEnumerable<DeskSimpleViewModel>>, IDeskGetAllBusinessLogic
    {
        public DeskGetAllBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeskGetAllBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override async Task<IEnumerable<DeskDto>> ExecutionAsync() =>
            await UnitOfWork.Desk.GetAll().ToListAsync();
    }
}