using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Validation;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fabian.Domurad.Golden.Card.Research.BL.Floor
{
    public class FloorGetDesksBusinessLogic : BaseBusinessLogic<FloorGetDesksBindingModel, IEnumerable<DeskDto>, IEnumerable<DeskSimpleViewModel>>, IFloorGetDesksBusinessLogic
    {
        public FloorGetDesksBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FloorGetDesksBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<FloorGetDesksBindingModel>> Validators => new[]
        {
            new FloorExistenceValidator(UnitOfWork),
        };

        protected override async Task<IEnumerable<DeskDto>> ExecutionAsync(FloorGetDesksBindingModel parameter) =>
            (await UnitOfWork.Floor.GetByIdAsync(parameter.FloorId)).Desks;
    }
}