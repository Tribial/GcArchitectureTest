using System.Collections.Generic;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.BL.Floor.Interface
{
    public interface IFloorGetDesksBusinessLogic : IBusinessLogic<FloorGetDesksBindingModel, IEnumerable<DeskSimpleViewModel>>
    {
    }
}
