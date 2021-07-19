using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.BL.User.Interface;
using Fabian.Domurad.Golden.Card.Research.BL.User.Internal;
using Fabian.Domurad.Golden.Card.Research.BL.User.Validation;
using Fabian.Domurad.Golden.Card.Research.Data;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fabian.Domurad.Golden.Card.Research.BL.User
{
    public class UserAuthenticateBusinessLogic : BaseBusinessLogic<UserAuthenticateBindingModel, TokenDto, TokenViewModel>, IUserAuthenticateBusinessLogic
    {
        private readonly GenerateTokenInternalLogic _generateToken;
        public UserAuthenticateBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserAuthenticateBusinessLogic> logger, IConfiguration configuration) : base(unitOfWork, mapper, logger)
        {
            _generateToken = new GenerateTokenInternalLogic(configuration);
        }

        protected override IEnumerable<IValidator<UserAuthenticateBindingModel>> Validators =>
            new IValidator<UserAuthenticateBindingModel>[]
            {
                new UserExistenceValidator(UnitOfWork),
                new UserPasswordValidator(UnitOfWork),
            };

        protected override async Task<TokenDto> ExecutionAsync(UserAuthenticateBindingModel parameter)
        {
            var userDto = await UnitOfWork.User.GetAll().FirstOrDefaultAsync(x => x.Username == parameter.Username);
            var tokenDto = _generateToken.Execute(userDto);
            return tokenDto;
        }
    }
}
