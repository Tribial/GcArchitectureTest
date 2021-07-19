using System;
using System.Net;
using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.BL.Floor.Interface;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fabian.Domurad.Golden.Card.Research.API.Controllers
{
    public class FloorController : BaseApiController
    {
        private readonly IFloorAddBusinessLogic _floorAddBusinessLogic;
        private readonly IFloorGetAllBusinessLogic _floorGetAllBusinessLogic;
        private readonly IFloorGetByIdBusinessLogic _floorGetByIdBusinessLogic;
        private readonly IFloorGetDesksBusinessLogic _floorGetDesksBusinessLogic;

        public FloorController(IFloorAddBusinessLogic floorAddBusinessLogic, IFloorGetAllBusinessLogic floorGetAllBusinessLogic, IFloorGetByIdBusinessLogic floorGetByIdBusinessLogic, IFloorGetDesksBusinessLogic floorGetDesksBusinessLogic)
        {
            _floorAddBusinessLogic = floorAddBusinessLogic;
            _floorGetAllBusinessLogic = floorGetAllBusinessLogic;
            _floorGetByIdBusinessLogic = floorGetByIdBusinessLogic;
            _floorGetDesksBusinessLogic = floorGetDesksBusinessLogic;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LocalizationViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        [Authorize(Roles = AuthConst.ModeratorRole + "," + AuthConst.AdministratorRole)]
        public async Task<IActionResult> AddAsync([FromBody] FloorAddBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return MapModelStateErrors(ModelState);
            }

            var result = await _floorAddBusinessLogic.ExecuteAsync(bindingModel);

            return MapResult(result);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LocalizationViewModel))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _floorGetAllBusinessLogic.ExecuteAsync();

            return MapResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LocalizationViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var result = await _floorGetByIdBusinessLogic.ExecuteAsync(new FloorGetByIdBindingModel {Id = id});

            return MapResult(result);
        }

        [HttpGet("{id}/desks")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LocalizationViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetDesksAsync([FromRoute] Guid id)
        {
            var result = await _floorGetDesksBusinessLogic.ExecuteAsync(new FloorGetDesksBindingModel {FloorId = id});

            return MapResult(result);
        }
    }
}
