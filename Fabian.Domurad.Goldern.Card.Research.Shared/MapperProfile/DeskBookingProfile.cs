using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.Shared.MapperProfile
{
    public class DeskBookingProfile : Profile
    {
        public DeskBookingProfile()
        {
            CreateMap<DeskBookingDto, DeskBookingEntity>();
            CreateMap<DeskBookingEntity, DeskBookingDto>();

            CreateMap<DeskBookingDto, DeskBookingSimpleViewModel>();
        }
    }
}
