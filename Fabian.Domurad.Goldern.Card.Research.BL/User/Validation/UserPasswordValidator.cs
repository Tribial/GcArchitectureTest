using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;
using Fabian.Domurad.Golden.Card.Research.Shared.Extension;

namespace Fabian.Domurad.Golden.Card.Research.BL.User.Validation
{
    public class UserPasswordValidator : IValidator<UserAuthenticateBindingModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserPasswordValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Validate(UserAuthenticateBindingModel param)
        {
            ValidatePasswordMatchesUsername(param.Username, param.Password);
        }

        private void ValidatePasswordMatchesUsername(string username, string password)
        {
            if(!_unitOfWork.User.ExistsAsync(x => x.Username == username && x.PasswordHash == password.ToHash()).Result)
            {
                throw new BusinessLogicException(ErrorMessageConst.UsernamePasswordNotMatch, ExceptionType.InvalidArgument);
            }
        }
    }
}
