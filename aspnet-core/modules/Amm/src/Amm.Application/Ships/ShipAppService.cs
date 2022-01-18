using Amm.Shared;
using Amm.ShipOperators;
using Amm.MasterDatas;
using Amm.Countries;
using Amm.Destinations;
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
using Amm.Ships;

namespace Amm.Ships
{

    [Authorize(AmmPermissions.Ships.Default)]
    public class ShipsAppService : ApplicationService, IShipsAppService
    {
        private readonly IShipRepository _shipRepository;
        private readonly IRepository<Destination, Guid> _destinationRepository;
        private readonly IRepository<Country, string> _countryRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;
        private readonly IRepository<ShipOperator, Guid> _shipOperatorRepository;

        public ShipsAppService(IShipRepository shipRepository, IRepository<Destination, Guid> destinationRepository, IRepository<Country, string> countryRepository, IRepository<MasterData, Guid> masterDataRepository, IRepository<ShipOperator, Guid> shipOperatorRepository)
        {
            _shipRepository = shipRepository; _destinationRepository = destinationRepository;
            _countryRepository = countryRepository;
            _masterDataRepository = masterDataRepository;
            _shipOperatorRepository = shipOperatorRepository;
        }

        public virtual async Task<PagedResultDto<ShipWithNavigationPropertiesDto>> GetListAsync(GetShipsInput input)
        {
            var totalCount = await _shipRepository.GetCountAsync(input.FilterText, input.ShipName, input.YearBuildMin, input.YearBuildMax, input.YearRefurbishedMin, input.YearRefurbishedMax, input.EnsuitedCabins, input.SharedToiletsMin, input.SharedToiletsMax, input.SharedShowersMin, input.SharedShowersMax, input.CrewNoMin, input.CrewNoMax, input.LenghtMin, input.LenghtMax, input.BeamMin, input.BeamMax, input.DraftMin, input.DraftMax, input.CruiseSpeedMin, input.CruiseSpeedMax, input.MaxSpeedMin, input.MaxSpeedMax, input.VideoUrl, input.UseCabinDeckPosition, input.UseDeckLocation, input.ShipEnabled, input.HomePort, input.Flag, input.ShipCategory, input.ShipOperator);
            var items = await _shipRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.ShipName, input.YearBuildMin, input.YearBuildMax, input.YearRefurbishedMin, input.YearRefurbishedMax, input.EnsuitedCabins, input.SharedToiletsMin, input.SharedToiletsMax, input.SharedShowersMin, input.SharedShowersMax, input.CrewNoMin, input.CrewNoMax, input.LenghtMin, input.LenghtMax, input.BeamMin, input.BeamMax, input.DraftMin, input.DraftMax, input.CruiseSpeedMin, input.CruiseSpeedMax, input.MaxSpeedMin, input.MaxSpeedMax, input.VideoUrl, input.UseCabinDeckPosition, input.UseDeckLocation, input.ShipEnabled, input.HomePort, input.Flag, input.ShipCategory, input.ShipOperator, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShipWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShipWithNavigationProperties>, List<ShipWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<ShipWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<ShipWithNavigationProperties, ShipWithNavigationPropertiesDto>
                (await _shipRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<ShipDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Ship, ShipDto>(await _shipRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetDestinationLookupAsync(LookupRequestDto input)
        {
            var query = (await _destinationRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.City != null &&
                         x.City.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Destination>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Destination>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<string>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            var query = (await _countryRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.CountryName != null &&
                         x.CountryName.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Country>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<string>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Country>, List<LookupDto<string>>>(lookupData)
            };
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

        public virtual async Task<PagedResultDto<LookupDto<Guid?>>> GetShipOperatorLookupAsync(LookupRequestDto input)
        {
            var query = (await _shipOperatorRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.OperatorName != null &&
                         x.OperatorName.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<ShipOperator>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid?>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShipOperator>, List<LookupDto<Guid?>>>(lookupData)
            };
        }

        [Authorize(AmmPermissions.Ships.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shipRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.Ships.Create)]
        public virtual async Task<ShipDto> CreateAsync(ShipCreateDto input)
        {
            if (input.HomePort == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Destination"]]);
            }
            if (input.Flag == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }
            if (input.ShipCategory == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var ship = ObjectMapper.Map<ShipCreateDto, Ship>(input);

            ship = await _shipRepository.InsertAsync(ship, autoSave: true);
            return ObjectMapper.Map<Ship, ShipDto>(ship);
        }

        [Authorize(AmmPermissions.Ships.Edit)]
        public virtual async Task<ShipDto> UpdateAsync(Guid id, ShipUpdateDto input)
        {
            if (input.HomePort == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Destination"]]);
            }
            if (input.Flag == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }
            if (input.ShipCategory == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }

            var ship = await _shipRepository.GetAsync(id);
            ObjectMapper.Map(input, ship);
            ship = await _shipRepository.UpdateAsync(ship, autoSave: true);
            return ObjectMapper.Map<Ship, ShipDto>(ship);
        }
    }
}