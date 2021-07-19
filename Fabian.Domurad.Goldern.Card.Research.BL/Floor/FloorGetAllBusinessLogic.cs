using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Internal;
using Fabian.Domurad.Golden.Card.Research.BL.Localization;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Fabian.Domurad.Golden.Card.Research.BL.Floor
{
    public class FloorGetAllBusinessLogic : BaseBusinessLogic<IEnumerable<FloorDto>, IEnumerable<FloorViewModel>>, IFloorGetAllBusinessLogic
    {
        private readonly FillDeskFloorObjInternalLogic _fillDeskFloorObj;
        public FloorGetAllBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FloorGetAllBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
            _fillDeskFloorObj = new FillDeskFloorObjInternalLogic();
        }

        protected override async Task<IEnumerable<FloorDto>> ExecutionAsync()
        {
            var result = await UnitOfWork.Floor.GetAll().ToListAsync();
            return _fillDeskFloorObj.Execute(result);
        }
    }
}
