using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.Shared.MapperProfile
{
    public class LocalizationProfile : Profile
    {
        public LocalizationProfile()
        {
            CreateMap<LocalizationDto, LocalizationEntity>();
            CreateMap<LocalizationEntity, LocalizationDto>();

            CreateMap<LocalizationAddBindingModel, LocalizationDto>();

            CreateMap<LocalizationDto, LocalizationViewModel>();
            CreateMap<LocalizationDto, LocalizationSimpleViewModel>();
        }
    }
}
