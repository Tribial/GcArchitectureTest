using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Data;
using System;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.BL.Localization.Validation
{
    public class LocalizationExistenceValidator : IValidator<LocalizationGetByIdBindingModel>, IValidator<FloorAddBindingModel>
    {
        private readonly IUnitOfWork _uniteOfWork;

        public LocalizationExistenceValidator(IUnitOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }

        public void Validate(LocalizationGetByIdBindingModel param)
        {
            ValidateExistenceById(param.Id);
        }

        public void Validate(FloorAddBindingModel param)
        {
            ValidateExistenceById(param.LocalizationId);
        }

        private void ValidateExistenceById(Guid id)
        {
            if (!_uniteOfWork.Localization.ExistsAsync(x => x.Id == id).Result)
            {
                throw new BusinessLogicException(string.Format(ErrorMessageConst.EntityNotFoundFormat,
                    nameof(_uniteOfWork.Localization), nameof(id), id), ExceptionType.InvalidArgument);
            }
        }
    }
}
