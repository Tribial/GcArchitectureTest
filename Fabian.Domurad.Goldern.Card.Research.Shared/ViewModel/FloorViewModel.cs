using System.Collections.Generic;

namespace Fabian.Domurad.Golden.Card.Research.Shared.ViewModel
{
    public class FloorViewModel : ViewModel
    {
        public int Number { get; set; }
        public LocalizationSimpleViewModel Localization { get; set; }

        public IEnumerable<DeskSimpleViewModel> Desks { get; set; }
    }
}
