using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;
using System;

namespace Fabian.Domurad.Golden.Card.Research.BL.Desk.Validation
{
    public class DeskExistenceValidator : IValidator<DeskGetByIdBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeskExistenceValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(DeskGetByIdBindingModel param)
        {
            ValidateExistenceById(param.Id);
        }

        public void ValidateExistenceById(Guid id)
        {
            if (!_unitOfWork.Desk.ExistsAsync(x => x.Id == id).Result)
            {
                throw new BusinessLogicException(string.Format(ErrorMessageConst.EntityNotFoundFormat,
                    nameof(_unitOfWork.Desk), nameof(id), id), ExceptionType.InvalidArgument);
            }
        }
    }
}
