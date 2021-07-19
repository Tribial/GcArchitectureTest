using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.Desk.Interface;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Validation;

namespace Fabian.Domurad.Golden.Card.Research.BL.Desk
{
    public class DeskGetRoomBusinessLogic : BaseBusinessLogic<DeskGetRoomBindingModel, IEnumerable<DeskDto>, IEnumerable<DeskViewModel>>, IDeskGetRoomBusinessLogic
    {
        public DeskGetRoomBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeskGetRoomBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<DeskGetRoomBindingModel>> Validators =>
            new IValidator<DeskGetRoomBindingModel>[]
            {
                new FloorExistenceValidator(UnitOfWork)
            };

        protected override async Task<IEnumerable<DeskDto>> ExecutionAsync(DeskGetRoomBindingModel parameter)
        {
            var z = await UnitOfWork.Desk.GetAll().Where(x => x.RoomNumber == parameter.RoomNumber && x.FloorId == parameter.FloorId).ToListAsync();
            return z;
        }
    }
}
