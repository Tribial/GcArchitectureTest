using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.Desk.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.Desk.Validation;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.Extensions.Logging;

namespace Fabian.Domurad.Golden.Card.Research.BL.Desk
{
    public class DeskGetByIdBusinessLogic : BaseBusinessLogic<DeskGetByIdBindingModel, DeskDto, DeskViewModel>, IDeskGetByIdBusinessLogic
    {
        public DeskGetByIdBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeskGetByIdBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<DeskGetByIdBindingModel>> Validators => new[]
        {
            new DeskExistenceValidator(UnitOfWork),
        };

        protected override async Task<DeskDto> ExecutionAsync(DeskGetByIdBindingModel parameter) =>
            await UnitOfWork.Desk.GetByIdAsync(parameter.Id);
    }
}