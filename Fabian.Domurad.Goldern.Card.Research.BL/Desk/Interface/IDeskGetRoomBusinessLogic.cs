using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using System.Collections.Generic;

namespace Fabian.Domurad.Golden.Card.Research.BL.Desk.Interface
{
    public interface IDeskGetRoomBusinessLogic : IBusinessLogic<DeskGetRoomBindingModel, IEnumerable<DeskViewModel>>
    {
    }
}
