using Fabian.Domurad.Golden.Card.Research.BL.Base;
using Fabian.Domurad.Golden.Card.Research.Shared.Constant;
using Fabian.Domurad.Golden.Card.Research.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fabian.Domurad.Golden.Card.Research.BL.Floor.Internal
{
    public class FillDeskFloorObjInternalLogic : IInternalLogic<FloorDto, FloorDto>, IInternalLogic<IEnumerable<FloorDto>, IEnumerable<FloorDto>>
    {
        [Obsolete(DevelopmentMessageConst.UseSyncMethod, false)]
        public async Task<FloorDto> ExecuteAsync(FloorDto param)
        {
            return await new Task<FloorDto>(() => Execute(param));
        }

        public FloorDto Execute(FloorDto param)
        {
            foreach (var desk in param.Desks)
            {
                desk.Floor = CutDesks(param);
            }

            return param;
        }

        [Obsolete(DevelopmentMessageConst.UseSyncMethod, false)]
        public async Task<IEnumerable<FloorDto>> ExecuteAsync(IEnumerable<FloorDto> param)
        {
            return await new Task<IEnumerable<FloorDto>>(() => param.Select(Execute));
        }

        public IEnumerable<FloorDto> Execute(IEnumerable<FloorDto> param)
        {
            return param.Select(Execute);
        }

        private FloorDto CutDesks(FloorDto floorDto)
        {
            return new FloorDto
            {
                Id = floorDto.Id,
                CreatedAt = floorDto.CreatedAt,
                LocalizationId = floorDto.LocalizationId,
                ModifiedAt = floorDto.ModifiedAt,
                Number = floorDto.Number,
                Localization = floorDto.Localization,
            };
        }
    }
}
