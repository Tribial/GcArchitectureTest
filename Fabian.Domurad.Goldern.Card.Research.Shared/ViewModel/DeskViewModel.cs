using System;
using System.Collections.Generic;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;

namespace Fabian.Domurad.Golden.Card.Research.Shared.ViewModel
{
    public class DeskViewModel : ViewModel
    {
        public int DeskNumber { get; set; }
        public int RoomNumber { get; set; }
        public bool IsLifted { get; set; }
        public bool IsUnavailable { get; set; }
        public DeskLocation Location { get; set; }
        public string Tribe { get; set; }

        public UserSimpleViewModel Owner { get; set; }
        public FloorSimpleViewModel Floor { get; set; }

        public IEnumerable<DeskBookingSimpleViewModel> DeskBookings { get; set; }

        public string DeskName { get; set; }
    }
}
