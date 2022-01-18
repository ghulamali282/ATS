using Amm.Shared;
using Amm.ShipDecks;
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
using Amm.ShipCabinTypes;

namespace Amm.ShipCabinTypes
{

    [Authorize(AmmPermissions.ShipCabinTypes.Default)]
    public class ShipCabinTypesAppService : ApplicationService, IShipCabinTypesAppService
    {
        private readonly IShipCabinTypeRepository _shipCabinTypeRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;
        private readonly IRepository<ShipDeck, Guid> _shipDeckRepository;

        public ShipCabinTypesAppService(IShipCabinTypeRepository shipCabinTypeRepository, IRepository<MasterData, Guid> masterDataRepository, IRepository<ShipDeck, Guid> shipDeckRepository)
        {
            _shipCabinTypeRepository = shipCabinTypeRepository; _masterDataRepository = masterDataRepository;
            _shipDeckRepository = shipDeckRepository;
        }

        public virtual async Task<PagedResultDto<ShipCabinTypeWithNavigationPropertiesDto>> GetListAsync(GetShipCabinTypesInput input)
        {
            var totalCount = await _shipCabinTypeRepository.GetCountAsync(input.FilterText, input.Ship, input.SortOrderMin, input.SortOrderMax, input.CabinCategory, input.Deck, input.DeckLocation, input.DeckPosition);
            var items = await _shipCabinTypeRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Ship, input.SortOrderMin, input.SortOrderMax, input.CabinCategory, input.Deck, input.DeckLocation, input.DeckPosition, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShipCabinTypeWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShipCabinTypeWithNavigationProperties>, List<ShipCabinTypeWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<ShipCabinTypeWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<ShipCabinTypeWithNavigationProperties, ShipCabinTypeWithNavigationPropertiesDto>
                (await _shipCabinTypeRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<ShipCabinTypeDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShipCabinType, ShipCabinTypeDto>(await _shipCabinTypeRepository.GetAsync(id));
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

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetShipDeckLookupAsync(LookupRequestDto input)
        {
            var query = (await _shipDeckRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.ShipDeckNameTEMP != null &&
                         x.ShipDeckNameTEMP.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<ShipDeck>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShipDeck>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(AmmPermissions.ShipCabinTypes.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shipCabinTypeRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.ShipCabinTypes.Create)]
        public virtual async Task<ShipCabinTypeDto> CreateAsync(ShipCabinTypeCreateDto input)
        {
            if (input.CabinCategory == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }
            if (input.Deck == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["ShipDeck"]]);
            }
            if (input.DeckLocation == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var shipCabinType = ObjectMapper.Map<ShipCabinTypeCreateDto, ShipCabinType>(input);

            shipCabinType = await _shipCabinTypeRepository.InsertAsync(shipCabinType, autoSave: true);
            return ObjectMapper.Map<ShipCabinType, ShipCabinTypeDto>(shipCabinType);
        }

        [Authorize(AmmPermissions.ShipCabinTypes.Edit)]
        public virtual async Task<ShipCabinTypeDto> UpdateAsync(Guid id, ShipCabinTypeUpdateDto input)
        {
            if (input.CabinCategory == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }
            if (input.Deck == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["ShipDeck"]]);
            }
            if (input.DeckLocation == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var shipCabinType = await _shipCabinTypeRepository.GetAsync(id);
            ObjectMapper.Map(input, shipCabinType);
            shipCabinType = await _shipCabinTypeRepository.UpdateAsync(shipCabinType, autoSave: true);
            return ObjectMapper.Map<ShipCabinType, ShipCabinTypeDto>(shipCabinType);
        }
    }
}