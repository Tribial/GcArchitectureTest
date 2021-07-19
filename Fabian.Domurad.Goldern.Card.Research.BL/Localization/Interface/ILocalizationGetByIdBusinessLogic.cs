using System;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.BL.Localization.Interface
{
    public interface ILocalizationGetByIdBusinessLogic : IBusinessLogic<LocalizationGetByIdBindingModel, LocalizationViewModel>
    {
    }
}
