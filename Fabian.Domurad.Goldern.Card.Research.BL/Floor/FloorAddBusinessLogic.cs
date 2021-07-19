using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Validation;
using Fabian.Domurad.Golden.Card.Research.BL.Localization.Validation;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fabian.Domurad.Golden.Card.Research.BL.Floor
{
    public class FloorAddBusinessLogic : BaseBusinessLogic<FloorAddBindingModel, FloorDto, FloorViewModel>, IFloorAddBusinessLogic
    {
        public FloorAddBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FloorAddBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<FloorAddBindingModel>> Validators => new IValidator<FloorAddBindingModel>[]
        {
            new LocalizationExistenceValidator(UnitOfWork),
            new FloorUniquenessValidator(UnitOfWork),
        };

        protected override async Task<FloorDto> ExecutionAsync(FloorAddBindingModel parameter)
        {
            var dto = Mapper.Map<FloorDto>(parameter);
            var id = await UnitOfWork.Floor.AddAsync(dto);

            return await UnitOfWork.Floor.GetByIdAsync(id);
        }
    }
}
