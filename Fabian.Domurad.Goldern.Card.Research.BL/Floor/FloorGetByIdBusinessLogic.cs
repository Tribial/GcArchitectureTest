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
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Internal;

namespace Fabian.Domurad.Golden.Card.Research.BL.Floor
{
    public class FloorGetByIdBusinessLogic : BaseBusinessLogic<FloorGetByIdBindingModel, FloorDto, FloorViewModel>, IFloorGetByIdBusinessLogic
    {
        private readonly FillDeskFloorObjInternalLogic _fillDeskFloorObj;
        public FloorGetByIdBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FloorGetByIdBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
            _fillDeskFloorObj = new FillDeskFloorObjInternalLogic();
        }

        protected override IEnumerable<IValidator<FloorGetByIdBindingModel>> Validators => new[]
        {
            new FloorExistenceValidator(UnitOfWork),
        };

        protected override async Task<FloorDto> ExecutionAsync(FloorGetByIdBindingModel parameter)
        {
            var floorDto = await UnitOfWork.Floor.GetByIdAsync(parameter.Id);
            return _fillDeskFloorObj.Execute(floorDto);
        }
    }
}
