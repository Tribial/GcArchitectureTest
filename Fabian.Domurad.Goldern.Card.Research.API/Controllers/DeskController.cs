using System;
using System.Net;
using System.Threading.Tasks;
using Fabian.Domurad.Golden.Card.Research.BL.Desk.Interface;
using Fabian.Domurad.Golden.Card.Research.Shared.BindingModel;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fabian.Domurad.Golden.Card.Research.API.Controllers
{
    public class DeskController : BaseApiController
    {
        private readonly IDeskAddBusinessLogic _deskAddBusinessLogic;
        private readonly IDeskGetAllBusinessLogic _deskGetAllBusinessLogic;
        private readonly IDeskGetByIdBusinessLogic _deskGetByIdBusinessLogic;
        private readonly IDeskGetRoomBusinessLogic _deskGetRoomBusinessLogic;

        public DeskController(IDeskAddBusinessLogic deskAddBusinessLogic, IDeskGetAllBusinessLogic deskGetAllBusinessLogic, IDeskGetByIdBusinessLogic deskGetByIdBusinessLogic, IDeskGetRoomBusinessLogic deskGetRoomBusinessLogic)
        {
            _deskAddBusinessLogic = deskAddBusinessLogic;
            _deskGetAllBusinessLogic = deskGetAllBusinessLogic;
            _deskGetByIdBusinessLogic = deskGetByIdBusinessLogic;
            _deskGetRoomBusinessLogic = deskGetRoomBusinessLogic;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DeskSimpleViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        [Authorize(Roles = AuthConst.ModeratorRole + "," + AuthConst.AdministratorRole)]
        public async Task<IActionResult> AddAsync([FromBody] DeskAddBindingModel bindingModel)
        {
            if (!ModelState.IsValid)
            {
                return MapModelStateErrors(ModelState);
            }

            var result = await _deskAddBusinessLogic.ExecuteAsync(bindingModel);
            return MapResult(result);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DeskSimpleViewModel))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _deskGetAllBusinessLogic.ExecuteAsync();
            return MapResult(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DeskSimpleViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var result = await _deskGetByIdBusinessLogic.ExecuteAsync(new DeskGetByIdBindingModel {Id = id});
            return MapResult(result);
        }

        [HttpGet("floor/{floorId}/room/{roomNumber}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(DeskSimpleViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetRoomAsync([FromRoute] Guid floorId, [FromRoute] int roomNumber)
        {
            var result = await _deskGetRoomBusinessLogic.ExecuteAsync(new DeskGetRoomBindingModel()
                {FloorId = floorId, RoomNumber = roomNumber});
            return MapResult(result);
        }
    }
}
