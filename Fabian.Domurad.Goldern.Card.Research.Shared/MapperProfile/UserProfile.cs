using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.Enum;
using Fabian.Domurad.Golden.Card.Research.Shared.Extension;
using Fabian.Domurad.Golden.Card.Research.Shared.Model;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;

namespace Fabian.Domurad.Golden.Card.Research.Shared.MapperProfile
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.Ignore());

            CreateMap<UserCreateBindingModel, UserDto>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password.ToHash()))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => UserRole.User));

            CreateMap<UserDto, UsernameViewModel>();
            CreateMap<UserDto, UserSimpleViewModel>();
        }
    }
}
