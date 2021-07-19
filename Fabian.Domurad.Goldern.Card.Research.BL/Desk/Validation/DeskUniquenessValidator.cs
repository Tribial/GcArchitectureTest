using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using System;
using System.Linq;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.BL.Desk.Validation
{
    public class DeskUniquenessValidator : IValidator<DeskAddBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeskUniquenessValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(DeskAddBindingModel param)
        {
            ValidateDeskNumbersUniqueness(param.DeskNumber, param.RoomNumber, param.FloorId);
        }

        private void ValidateDeskNumbersUniqueness(int deskNumber, int roomNumber, Guid floorId)
        {
            var desk = _unitOfWork.Desk.GetAll().FirstOrDefault(x =>
                x.DeskNumber == deskNumber && x.RoomNumber == roomNumber && x.FloorId == floorId);
            if (desk != null)
            {
                throw new BusinessLogicException(string.Format(ErrorMessageConst.DeskAlreadyExistsFormat, desk.DeskName,
                    desk.Floor.Localization.Name), ExceptionType.InvalidArgument);
            }
        }
    }
}
