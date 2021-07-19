using System.Collections.Generic;

namespace Fabian.Domurad.Golden.Card.Research.Shared.ViewModel
{
    public class LocalizationViewModel : ViewModel
    {
        public string Name { get; set; }

        public IEnumerable<FloorSimpleViewModel> Floors { get; set; }
    }
}
