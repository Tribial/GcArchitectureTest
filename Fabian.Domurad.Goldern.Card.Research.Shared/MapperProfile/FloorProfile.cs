using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.Shared.MapperProfile
{
    public class FloorProfile : Profile
    {
        public FloorProfile()
        {
            CreateMap<FloorDto, FloorEntity>();
            CreateMap<FloorEntity, FloorDto>();

            CreateMap<FloorAddBindingModel, FloorDto>();

            CreateMap<FloorDto, FloorViewModel>();
            CreateMap<FloorDto, FloorSimpleViewModel>()
                .ForMember(dest => dest.LocalizationName, opt => opt.MapFrom(src => src.Localization.Name));
        }
    }
}
