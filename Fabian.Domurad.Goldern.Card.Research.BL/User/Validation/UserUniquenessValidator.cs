using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using System;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.BL.User.Validation
{
    public class UserUniquenessValidator : IValidator<UserCreateBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserUniquenessValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(UserCreateBindingModel param)
        {
            ValidateUserUniquenessByUsername(param.Username);
            ValidateUserUniquenessByEmail(param.Email);
        }

        private void ValidateUserUniquenessByUsername(string username)
        {
            if (_unitOfWork.User.ExistsAsync(x => x.Username == username).Result)
            {
                ThrowException("username", username);
            }
        }

        private void ValidateUserUniquenessByEmail(string email)
        {
            if (_unitOfWork.User.ExistsAsync(x => x.Email == email).Result)
            {
                ThrowException("email", email);
            }
        }

        private void ThrowException(string propName, string propValue)
        {
            throw new BusinessLogicException(
                string.Format(ErrorMessageConst.AlreadyExistsFormat, nameof(_unitOfWork.User), propName,
                    propValue), ExceptionType.InvalidArgument);
        }
    }
}
