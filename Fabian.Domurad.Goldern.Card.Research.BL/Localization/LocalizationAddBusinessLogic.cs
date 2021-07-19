using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.Localization.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.Localization.Validation;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Fabian.Domurad.Golden.Card.Research.BL.Localization
{
    public class LocalizationAddBusinessLogic : BaseBusinessLogic<LocalizationAddBindingModel, LocalizationDto, LocalizationViewModel>, ILocalizationAddBusinessLogic
    {
        public LocalizationAddBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<LocalizationAddBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<LocalizationAddBindingModel>> Validators => new[]
        {
            new LocalizationUniquenessValidator(UnitOfWork),
        };

        protected override async Task<LocalizationDto> ExecutionAsync(LocalizationAddBindingModel parameter)
        {
            var dto = Mapper.Map<LocalizationDto>(parameter);
            var id = await UnitOfWork.Localization.AddAsync(dto);

            return await UnitOfWork.Localization.GetByIdAsync(id);
        }
    }
}
