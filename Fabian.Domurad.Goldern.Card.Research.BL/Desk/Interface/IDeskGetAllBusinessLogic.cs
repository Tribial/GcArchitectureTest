using System.Collections.Generic;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.BL.Desk.Interface
{
    public interface IDeskGetAllBusinessLogic : IBusinessLogic<IEnumerable<DeskSimpleViewModel>>
    {
    }
}
