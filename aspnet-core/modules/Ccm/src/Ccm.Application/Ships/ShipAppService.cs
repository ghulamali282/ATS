using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Ccm.Permissions;
using Ccm.Ships;

namespace Ccm.Ships
{

    [Authorize(CcmPermissions.Ships.Default)]
    public class ShipsAppService : ApplicationService, IShipsAppService
    {
        private readonly IShipRepository _shipRepository;

        public ShipsAppService(IShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }

        public virtual async Task<PagedResultDto<ShipDto>> GetListAsync(GetShipsInput input)
        {
            var totalCount = await _shipRepository.GetCountAsync(input.FilterText, input.ShipName, input.ShipCategory, input.ShipOperator, input.Type, input.Flag, input.HomePort, input.Manufacturer, input.Model, input.YearBuildMin, input.YearBuildMax);
            var items = await _shipRepository.GetListAsync(input.FilterText, input.ShipName, input.ShipCategory, input.ShipOperator, input.Type, input.Flag, input.HomePort, input.Manufacturer, input.Model, input.YearBuildMin, input.YearBuildMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShipDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Ship>, List<ShipDto>>(items)
            };
        }

        public virtual async Task<ShipDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Ship, ShipDto>(await _shipRepository.GetAsync(id));
        }

        [Authorize(CcmPermissions.Ships.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shipRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.Ships.Create)]
        public virtual async Task<ShipDto> CreateAsync(ShipCreateDto input)
        {

            var ship = ObjectMapper.Map<ShipCreateDto, Ship>(input);
            ship.TenantId = CurrentTenant.Id;
            ship = await _shipRepository.InsertAsync(ship, autoSave: true);
            return ObjectMapper.Map<Ship, ShipDto>(ship);
        }

        [Authorize(CcmPermissions.Ships.Edit)]
        public virtual async Task<ShipDto> UpdateAsync(Guid id, ShipUpdateDto input)
        {

            var ship = await _shipRepository.GetAsync(id);
            ObjectMapper.Map(input, ship);
            ship = await _shipRepository.UpdateAsync(ship, autoSave: true);
            return ObjectMapper.Map<Ship, ShipDto>(ship);
        }
    }
}