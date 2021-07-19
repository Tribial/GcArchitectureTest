using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.User.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.User.Validation;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.Extensions.Logging;

namespace Fabian.Domurad.Golden.Card.Research.BL.User
{
    public class UserCreateBusinessLogic : BaseBusinessLogic<UserCreateBindingModel, UserDto, UsernameViewModel>, IUserCreateBusinessLogic
    {
        public UserCreateBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserCreateBusinessLogic> logger) : base(unitOfWork, mapper, logger)
        {
        }

        protected override IEnumerable<IValidator<UserCreateBindingModel>> Validators => new[]
        {
            new UserUniquenessValidator(UnitOfWork),
        };

        protected override async Task<UserDto> ExecutionAsync(UserCreateBindingModel parameter)
        {
            var userDto = Mapper.Map<UserDto>(parameter);
            var id = await UnitOfWork.User.AddAsync(userDto);
            return await UnitOfWork.User.GetByIdAsync(id);
        }
    }
}
