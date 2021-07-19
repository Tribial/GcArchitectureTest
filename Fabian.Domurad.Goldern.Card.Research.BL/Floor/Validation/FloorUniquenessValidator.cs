using System;
using System.Linq;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.BL.Floor.Validation
{
    public class FloorUniquenessValidator : IValidator<FloorAddBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FloorUniquenessValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(FloorAddBindingModel param)
        {
            ValidateFloorNumberUniquenessWithinLocalization(param.Number, param.LocalizationId);
        }

        private void ValidateFloorNumberUniquenessWithinLocalization(int floorNumber, Guid locId)
        {
            var floor = _unitOfWork.Floor.GetAll()
                .FirstOrDefault(x => x.Number == floorNumber && x.LocalizationId == locId);
            if (floor != null)
            {
                throw new BusinessLogicException(string.Format(ErrorMessageConst.FloorNumberInLocAlreadyExistsFormat,
                    floorNumber, floor.Localization.Name), ExceptionType.InvalidArgument);
            }
        }
    }
}
