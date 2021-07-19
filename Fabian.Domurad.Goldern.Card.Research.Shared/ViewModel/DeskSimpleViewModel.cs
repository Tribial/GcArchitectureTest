using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.Shared.ViewModel
{
    public class DeskSimpleViewModel : ViewModel
    {
        public int DeskNumber { get; set; }
        public int RoomNumber { get; set; }
        public bool IsLifted { get; set; }
        public bool IsUnavailable { get; set; }
        public DeskLocation Location { get; set; }
        public string Tribe { get; set; }
        public int FloorNumber { get; set; }
        public string LocalizationName { get; set; }
        public string DeskName { get; set; }
    }
}
