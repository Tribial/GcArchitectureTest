using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.Shared.MapperProfile
{
    public class DeskProfile : Profile
    {
        public DeskProfile()
        {
            CreateMap<DeskDto, DeskEntity>();
            CreateMap<DeskEntity, DeskDto>()
                .ForMember(dest => dest.DeskName, opt => opt.Ignore());

            CreateMap<DeskDto, DeskSimpleViewModel>()
                .ForMember(dest => dest.FloorNumber, opt => opt.MapFrom(src => src.Floor.Number))
                .ForMember(dest => dest.LocalizationName, opt => opt.MapFrom(src => src.Floor.Localization.Name));
            CreateMap<DeskDto, DeskViewModel>();

            CreateMap<DeskAddBindingModel, DeskDto>();
        }
    }
}
