using Fabian.Domurad.Golden.Card.Research.BL.Localization.Interface;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Fabian.Domurad.Golden.Card.Research.API.Controllers
{
    public class LocalizationController : BaseApiController
    {
        private readonly ILocalizationAddBusinessLogic _localizationAddBusinessLogic;
        private readonly ILocalizationGetAllBusinessLogic _localizationGetAllBusinessLogic;
        private readonly ILocalizationGetByIdBusinessLogic _localizationGetByIdBusinessLogic;

        public LocalizationController(ILocalizationAddBusinessLogic localizationAddBusinessLogic,
            ILocalizationGetAllBusinessLogic localizationGetAllBusinessLogic,
            ILocalizationGetByIdBusinessLogic localizationGetByIdBusinessLogic)
        {
            _localizationAddBusinessLogic = localizationAddBusinessLogic;
            _localizationGetAllBusinessLogic = localizationGetAllBusinessLogic;
            _localizationGetByIdBusinessLogic = localizationGetByIdBusinessLogic;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LocalizationViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        [Authorize(Roles = AuthConst.ModeratorRole + "," + AuthConst.AdministratorRole)]
        public async Task<IActionResult> AddAsync([FromBody] LocalizationAddBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return MapModelStateErrors(ModelState);
            }

            var result = await _localizationAddBusinessLogic.ExecuteAsync(bindingModel);

            return MapResult(result);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LocalizationViewModel))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _localizationGetAllBusinessLogic.ExecuteAsync();

            return MapResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LocalizationViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var result =
                await _localizationGetByIdBusinessLogic.ExecuteAsync(new LocalizationGetByIdBindingModel {Id = id});

            return MapResult(result);
        }
    }
}
