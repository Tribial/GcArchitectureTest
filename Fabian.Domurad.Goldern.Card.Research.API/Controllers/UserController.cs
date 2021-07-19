using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.BL.User.Interface;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fabian.Domurad.Golden.Card.Research.API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserCreateBusinessLogic _userCreateBusinessLogic;
        private readonly IUserAuthenticateBusinessLogic _userAuthenticateBusinessLogic;

        public UserController(IUserCreateBusinessLogic userCreateBusinessLogic, IUserAuthenticateBusinessLogic userAuthenticateBusinessLogic)
        {
            _userCreateBusinessLogic = userCreateBusinessLogic;
            _userAuthenticateBusinessLogic = userAuthenticateBusinessLogic;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreateBindingModel bindingModel)
        {
            if(!ModelState.IsValid)
            {
                return MapModelStateErrors(ModelState);
            }

            var result = await _userCreateBusinessLogic.ExecuteAsync(bindingModel);
            return MapResult(result);
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UserAuthenticateBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return MapModelStateErrors(ModelState);
            }

            var result = await _userAuthenticateBusinessLogic.ExecuteAsync(bindingModel);
            return MapResult(result);
        }
    }
}
