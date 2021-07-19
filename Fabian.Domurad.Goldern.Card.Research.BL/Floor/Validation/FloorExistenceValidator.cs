using System;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.BL.Floor.Validation
{
    public class FloorExistenceValidator : 
        IValidator<FloorGetByIdBindingModel>, 
        IValidator<DeskAddBindingModel>, 
        IValidator<FloorGetDesksBindingModel>,
        IValidator<DeskGetRoomBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FloorExistenceValidator(IUnitOfWork uniteOfWork)
        {
            _unitOfWork = uniteOfWork;
        }

        public void Validate(FloorGetByIdBindingModel param)
        {
            ValidateExistenceById(param.Id);
        }

        public void Validate(DeskAddBindingModel param)
        {
            ValidateExistenceById(param.FloorId);
        }

        public void Validate(FloorGetDesksBindingModel param)
        {
            ValidateExistenceById(param.FloorId);
        }

        public void Validate(DeskGetRoomBindingModel param)
        {
            ValidateExistenceById(param.FloorId);
        }

        private void ValidateExistenceById(Guid id)
        {
            if (!_unitOfWork.Floor.ExistsAsync(x => x.Id == id).Result)
            {
                throw new BusinessLogicException(string.Format(ErrorMessageConst.EntityNotFoundFormat,
                    nameof(_unitOfWork.Floor), nameof(id), id), ExceptionType.InvalidArgument);
            }
        }
    }
}
