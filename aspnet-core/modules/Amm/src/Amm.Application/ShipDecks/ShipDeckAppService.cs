using Amm.Shared;
using Amm.MasterDatas;
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
using Amm.Permissions;
using Amm.ShipDecks;

namespace Amm.ShipDecks
{

    [Authorize(AmmPermissions.ShipDecks.Default)]
    public class ShipDecksAppService : ApplicationService, IShipDecksAppService
    {
        private readonly IShipDeckRepository _shipDeckRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;

        public ShipDecksAppService(IShipDeckRepository shipDeckRepository, IRepository<MasterData, Guid> masterDataRepository)
        {
            _shipDeckRepository = shipDeckRepository; _masterDataRepository = masterDataRepository;
        }

        public virtual async Task<PagedResultDto<ShipDeckWithNavigationPropertiesDto>> GetListAsync(GetShipDecksInput input)
        {
            var totalCount = await _shipDeckRepository.GetCountAsync(input.FilterText, input.ShipDeckNameTEMP, input.SortOrderMin, input.SortOrderMax, input.Ship, input.Deck);
            var items = await _shipDeckRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.ShipDeckNameTEMP, input.SortOrderMin, input.SortOrderMax, input.Ship, input.Deck, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShipDeckWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShipDeckWithNavigationProperties>, List<ShipDeckWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<ShipDeckWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<ShipDeckWithNavigationProperties, ShipDeckWithNavigationPropertiesDto>
                (await _shipDeckRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<ShipDeckDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShipDeck, ShipDeckDto>(await _shipDeckRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            var query = (await _masterDataRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<MasterData>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MasterData>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(AmmPermissions.ShipDecks.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shipDeckRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.ShipDecks.Create)]
        public virtual async Task<ShipDeckDto> CreateAsync(ShipDeckCreateDto input)
        {
            if (input.Deck == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var shipDeck = ObjectMapper.Map<ShipDeckCreateDto, ShipDeck>(input);

            shipDeck = await _shipDeckRepository.InsertAsync(shipDeck, autoSave: true);
            return ObjectMapper.Map<ShipDeck, ShipDeckDto>(shipDeck);
        }

        [Authorize(AmmPermissions.ShipDecks.Edit)]
        public virtual async Task<ShipDeckDto> UpdateAsync(Guid id, ShipDeckUpdateDto input)
        {
            if (input.Deck == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var shipDeck = await _shipDeckRepository.GetAsync(id);
            ObjectMapper.Map(input, shipDeck);
            shipDeck = await _shipDeckRepository.UpdateAsync(shipDeck, autoSave: true);
            return ObjectMapper.Map<ShipDeck, ShipDeckDto>(shipDeck);
        }
    }
}