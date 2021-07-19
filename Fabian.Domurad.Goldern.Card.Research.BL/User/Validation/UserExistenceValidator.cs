using System;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.BL.User.Validation
{
    public class UserExistenceValidator : IValidator<UserAuthenticateBindingModel>, IValidator<DeskAddBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserExistenceValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(UserAuthenticateBindingModel param)
        {
            ValidateUserExistenceByUsername(param.Username);
        }

        public void Validate(DeskAddBindingModel param)
        {
            if (param.OwnerId.HasValue)
            {
                ValidateUserExistenceById(param.OwnerId.Value);
            }
        }

        private void ValidateUserExistenceByUsername(string username)
        {
            if(!_unitOfWork.User.ExistsAsync(x => x.Username == username).Result)
            {
                throw new BusinessLogicException(string.Format(ErrorMessageConst.EntityNotFoundFormat,
                    nameof(_unitOfWork.User), nameof(username), username), ExceptionType.InvalidArgument);
            }
        }

        private void ValidateUserExistenceById(Guid id)
        {
            if (!_unitOfWork.User.ExistsAsync(x => x.Id == id).Result)
            {
                throw new BusinessLogicException(string.Format(ErrorMessageConst.EntityNotFoundFormat,
                    nameof(_unitOfWork.User), nameof(id), id), ExceptionType.InvalidArgument);
            }
        }
    }
}
