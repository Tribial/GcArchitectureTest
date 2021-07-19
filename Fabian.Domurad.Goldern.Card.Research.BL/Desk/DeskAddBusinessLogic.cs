using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.Desk.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.Desk.Validation;
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Validation;
using Fabian.Domurad.Golden.Card.Research.BL.User.Validation;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fabian.Domurad.Golden.Card.Research.BL.Desk
{
    public class DeskAddBusinessLogic : BaseBusinessLogic<DeskAddBindingModel, DeskDto, DeskSimpleViewModel>, IDeskAddBusinessLogic
    {
        public DeskAddBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeskAddBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<DeskAddBindingModel>> Validators =>
            new IValidator<DeskAddBindingModel>[]
            {
                new DeskUniquenessValidator(UnitOfWork),
                new FloorExistenceValidator(UnitOfWork),
                new DeskOwnerInUnavailableDeskOnlyValidator(),
                new UserExistenceValidator(UnitOfWork),
            };

        protected override async Task<DeskDto> ExecutionAsync(DeskAddBindingModel parameter)
        {
            var deskDto = Mapper.Map<DeskDto>(parameter);
            var id = await UnitOfWork.Desk.AddAsync(deskDto);
            return await UnitOfWork.Desk.GetByIdAsync(id);
        }
    }
}
