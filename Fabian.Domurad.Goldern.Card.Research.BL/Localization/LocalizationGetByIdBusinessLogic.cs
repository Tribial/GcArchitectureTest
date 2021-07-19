using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.Localization.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.Localization.Validation;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;

namespace Fabian.Domurad.Golden.Card.Research.BL.Localization
{
    public class LocalizationGetByIdBusinessLogic : BaseBusinessLogic<LocalizationGetByIdBindingModel, LocalizationDto, LocalizationViewModel>, ILocalizationGetByIdBusinessLogic
    {
        public LocalizationGetByIdBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<LocalizationGetByIdBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<LocalizationGetByIdBindingModel>> Validators => new[]
        {
            new LocalizationExistenceValidator(UnitOfWork),
        };

        protected override async Task<LocalizationDto> ExecutionAsync(LocalizationGetByIdBindingModel parameter) =>
            await UnitOfWork.Localization.GetByIdAsync(parameter.Id);
    }
}
