using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.BL.Localization.Validation
{
    public class LocalizationUniquenessValidator : IValidator<LocalizationAddBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocalizationUniquenessValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(LocalizationAddBindingModel param)
        {
            ValidateNameUniqueness(param.Name);
        }

        private void ValidateNameUniqueness(string name)
        {
            if(_unitOfWork.Localization.ExistsAsync(x => x.Name == name).Result)
            {
                throw new BusinessLogicException(string.Format(ErrorMessageConst.AlreadyExistsFormat,
                    nameof(Localization), nameof(name), name), ExceptionType.InvalidArgument);
            }
        }
    }
}
