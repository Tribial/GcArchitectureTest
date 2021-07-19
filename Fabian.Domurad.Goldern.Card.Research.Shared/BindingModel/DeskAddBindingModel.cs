using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fabian.Domurad.Golden.Card.Research.Shared.BindingModel
{
    public class DeskAddBindingModel
    {
        [Required(ErrorMessage = BindingModelErrorConst.DeskDeskNumberRequired)]
        public int DeskNumber { get; set; }

        [Required(ErrorMessage = BindingModelErrorConst.DeskRoomNumberRequired)]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = BindingModelErrorConst.DeskIsLiftedRequired)]
        public bool IsLifted { get; set; }

        [Required(ErrorMessage = BindingModelErrorConst.DeskIsUnavailableRequired)]
        public bool IsUnavailable { get; set; }

        [Required(ErrorMessage = BindingModelErrorConst.DeskLocationRequired)]
        public DeskLocation Location { get; set; }

        [Required(ErrorMessage = BindingModelErrorConst.DeskTribeRequired)]
        [MinLength(3, ErrorMessage = BindingModelErrorConst.DeskTribeMinLength)]
        [MaxLength(128, ErrorMessage = BindingModelErrorConst.DeskTribeMaxLength)]
        public string Tribe { get; set; }

        public Guid? OwnerId { get; set; }

        [Required(ErrorMessage = BindingModelErrorConst.DeskFloorIdRequired)]
        public Guid FloorId { get; set; }
    }
}
