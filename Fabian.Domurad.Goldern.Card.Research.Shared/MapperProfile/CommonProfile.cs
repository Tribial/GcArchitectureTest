using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.Shared.MapperProfile
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<Dto.Dto, ViewModel.ViewModel>();

            CreateMap<TokenDto, TokenViewModel>();
        }
    }
}
