using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.Localization.Interface;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Fabian.Domurad.Golden.Card.Research.BL.Localization
{
    public class LocalizationGetAllBusinessLogic : BaseBusinessLogic<IEnumerable<LocalizationDto>, IEnumerable<LocalizationViewModel>>, ILocalizationGetAllBusinessLogic
    {
        public LocalizationGetAllBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<LocalizationGetAllBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override async Task<IEnumerable<LocalizationDto>> ExecutionAsync() =>
            await UnitOfWork.Localization.GetAll().ToListAsync();
    }
}
