﻿using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.BL.User.Interface
{
    public interface IUserAuthenticateBusinessLogic : IBusinessLogic<UserAuthenticateBindingModel, TokenViewModel>
    {
    }
}
