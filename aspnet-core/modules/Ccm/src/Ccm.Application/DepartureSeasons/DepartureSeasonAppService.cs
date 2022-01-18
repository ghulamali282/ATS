using Ccm.Shared;
using Ccm.Partners;
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
using Ccm.DepartureSeasons;

namespace Ccm.DepartureSeasons
{

    [Authorize(CcmPermissions.DepartureSeasons.Default)]
    public class DepartureSeasonsAppService : ApplicationService, IDepartureSeasonsAppService
    {
        private readonly IDepartureSeasonRepository _departureSeasonRepository;
        private readonly IRepository<Partner, Guid> _partnerRepository;

        public DepartureSeasonsAppService(IDepartureSeasonRepository departureSeasonRepository, IRepository<Partner, Guid> partnerRepository)
        {
            _departureSeasonRepository = departureSeasonRepository; _partnerRepository = partnerRepository;
        }

        public virtual async Task<PagedResultDto<DepartureSeasonWithNavigationPropertiesDto>> GetListAsync(GetDepartureSeasonsInput input)
        {
            var totalCount = await _departureSeasonRepository.GetCountAsync(input.FilterText, input.SeasonMin, input.SeasonMax, input.SeasonName, input.Partner);
            var items = await _departureSeasonRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.SeasonMin, input.SeasonMax, input.SeasonName, input.Partner, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<DepartureSeasonWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<DepartureSeasonWithNavigationProperties>, List<DepartureSeasonWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<DepartureSeasonWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<DepartureSeasonWithNavigationProperties, DepartureSeasonWithNavigationPropertiesDto>
                (await _departureSeasonRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<DepartureSeasonDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<DepartureSeason, DepartureSeasonDto>(await _departureSeasonRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input)
        {
            var query = (await _partnerRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.PartnerName != null &&
                         x.PartnerName.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Partner>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Partner>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(CcmPermissions.DepartureSeasons.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _departureSeasonRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.DepartureSeasons.Create)]
        public virtual async Task<DepartureSeasonDto> CreateAsync(DepartureSeasonCreateDto input)
        {
            if (input.Partner == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }

            var departureSeason = ObjectMapper.Map<DepartureSeasonCreateDto, DepartureSeason>(input);
            departureSeason.TenantId = CurrentTenant.Id;
            departureSeason = await _departureSeasonRepository.InsertAsync(departureSeason, autoSave: true);
            return ObjectMapper.Map<DepartureSeason, DepartureSeasonDto>(departureSeason);
        }

        [Authorize(CcmPermissions.DepartureSeasons.Edit)]
        public virtual async Task<DepartureSeasonDto> UpdateAsync(Guid id, DepartureSeasonUpdateDto input)
        {
            if (input.Partner == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }

            var departureSeason = await _departureSeasonRepository.GetAsync(id);
            ObjectMapper.Map(input, departureSeason);
            departureSeason = await _departureSeasonRepository.UpdateAsync(departureSeason, autoSave: true);
            return ObjectMapper.Map<DepartureSeason, DepartureSeasonDto>(departureSeason);
        }
    }
}