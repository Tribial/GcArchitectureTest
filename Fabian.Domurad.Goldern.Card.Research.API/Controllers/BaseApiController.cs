using System.Linq;
using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Fabian.Domurad.Golden.Card.Research.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult MapResult<T>(ResultDto<T> result)
        {
            return !result.ErrorOccurred ? Ok(result.Data) : StatusCode((int) result.Type, result.Error);
        }

        protected IActionResult MapModelStateErrors(ModelStateDictionary modelState)
        {
            var errorMessage = modelState.Values.FirstOrDefault()?.Errors.FirstOrDefault()?.ErrorMessage ?? ErrorMessageConst.DefaultModelState;
            return BadRequest(errorMessage);
        }
    }
}
