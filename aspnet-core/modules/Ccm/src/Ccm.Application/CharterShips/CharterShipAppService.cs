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
using Ccm.CharterShips;

namespace Ccm.CharterShips
{

    [Authorize(CcmPermissions.CharterShips.Default)]
    public class CharterShipsAppService : ApplicationService, ICharterShipsAppService
    {
        private readonly ICharterShipRepository _charterShipRepository;

        public CharterShipsAppService(ICharterShipRepository charterShipRepository)
        {
            _charterShipRepository = charterShipRepository;
        }

        public virtual async Task<PagedResultDto<CharterShipDto>> GetListAsync(GetCharterShipsInput input)
        {
            var totalCount = await _charterShipRepository.GetCountAsync(input.FilterText, input.OperatorName, input.SeasonMin, input.SeasonMax, input.ShipNamePrefix, input.Ship, input.Itinerary, input.Tabs, input.Video, input.Featured, input.FreeInternetOnBoard, input.Internet, input.TransferIncluded, input.EnabledByUser, input.DisabledBySystemMin, input.DisabledBySystemMax, input.B2B, input.B2C, input.B2B_Agent, input.B2C_Agent, input.ShipAmenities, input.ShipArticles, input.ShipPhotos, input.CabinAmenities, input.CabinArticles, input.CabinPhotos);
            var items = await _charterShipRepository.GetListAsync(input.FilterText, input.OperatorName, input.SeasonMin, input.SeasonMax, input.ShipNamePrefix, input.Ship, input.Itinerary, input.Tabs, input.Video, input.Featured, input.FreeInternetOnBoard, input.Internet, input.TransferIncluded, input.EnabledByUser, input.DisabledBySystemMin, input.DisabledBySystemMax, input.B2B, input.B2C, input.B2B_Agent, input.B2C_Agent, input.ShipAmenities, input.ShipArticles, input.ShipPhotos, input.CabinAmenities, input.CabinArticles, input.CabinPhotos, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CharterShipDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CharterShip>, List<CharterShipDto>>(items)
            };
        }

        public virtual async Task<CharterShipDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CharterShip, CharterShipDto>(await _charterShipRepository.GetAsync(id));
        }

        [Authorize(CcmPermissions.CharterShips.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _charterShipRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.CharterShips.Create)]
        public virtual async Task<CharterShipDto> CreateAsync(CharterShipCreateDto input)
        {

            var charterShip = ObjectMapper.Map<CharterShipCreateDto, CharterShip>(input);
            charterShip.TenantId = CurrentTenant.Id;
            charterShip = await _charterShipRepository.InsertAsync(charterShip, autoSave: true);
            return ObjectMapper.Map<CharterShip, CharterShipDto>(charterShip);
        }

        [Authorize(CcmPermissions.CharterShips.Edit)]
        public virtual async Task<CharterShipDto> UpdateAsync(Guid id, CharterShipUpdateDto input)
        {

            var charterShip = await _charterShipRepository.GetAsync(id);
            ObjectMapper.Map(input, charterShip);
            charterShip = await _charterShipRepository.UpdateAsync(charterShip, autoSave: true);
            return ObjectMapper.Map<CharterShip, CharterShipDto>(charterShip);
        }
    }
}