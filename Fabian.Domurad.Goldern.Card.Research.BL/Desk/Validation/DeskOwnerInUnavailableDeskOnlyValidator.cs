using System;
using System.Collections.Generic;
using System.Text;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.CustomException;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.BL.Desk.Validation
{
    public class DeskOwnerInUnavailableDeskOnlyValidator : IValidator<DeskAddBindingModel>
    {
        public void Validate(DeskAddBindingModel param)
        {
            ValidateOwnerIsSetOnlyInUnavailableDesk(param.OwnerId, param.IsUnavailable);
        }

        private void ValidateOwnerIsSetOnlyInUnavailableDesk(Guid? ownerId, bool isUnavailable)
        {
            if (ownerId.HasValue && !isUnavailable)
            {
                throw new BusinessLogicException(ErrorMessageConst.OwnerOnlyInUnavailableDesk,
                    ExceptionType.InvalidArgument);
            }
        }
    }
}
