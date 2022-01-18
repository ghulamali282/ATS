using Ccm.Shared;
using Ccm.DepartureSeasons;
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
using Ccm.Departures;

namespace Ccm.Departures
{

    [Authorize(CcmPermissions.Departures.Default)]
    public class DeparturesAppService : ApplicationService, IDeparturesAppService
    {
        private readonly IDepartureRepository _departureRepository;
        private readonly IRepository<Partner, Guid> _partnerRepository;
        private readonly IRepository<DepartureSeason, Guid> _departureSeasonRepository;

        public DeparturesAppService(IDepartureRepository departureRepository, IRepository<Partner, Guid> partnerRepository, IRepository<DepartureSeason, Guid> departureSeasonRepository)
        {
            _departureRepository = departureRepository; _partnerRepository = partnerRepository;
            _departureSeasonRepository = departureSeasonRepository;
        }

        public virtual async Task<PagedResultDto<DepartureWithNavigationPropertiesDto>> GetListAsync(GetDeparturesInput input)
        {
            var totalCount = await _departureRepository.GetCountAsync(input.FilterText, input.DeparturesArray, input.SeasonGroup, input.Partner, input.SeasonName);
            var items = await _departureRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.DeparturesArray, input.SeasonGroup, input.Partner, input.SeasonName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<DepartureWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<DepartureWithNavigationProperties>, List<DepartureWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<DepartureWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<DepartureWithNavigationProperties, DepartureWithNavigationPropertiesDto>
                (await _departureRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<DepartureDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Departure, DepartureDto>(await _departureRepository.GetAsync(id));
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

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetDepartureSeasonLookupAsync(LookupRequestDto input)
        {
            var query = (await _departureSeasonRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.SeasonName != null &&
                         x.SeasonName.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<DepartureSeason>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<DepartureSeason>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(CcmPermissions.Departures.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _departureRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.Departures.Create)]
        public virtual async Task<DepartureDto> CreateAsync(DepartureCreateDto input)
        {
            if (input.Partner == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }
            if (input.SeasonName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["DepartureSeason"]]);
            }

            var departure = ObjectMapper.Map<DepartureCreateDto, Departure>(input);
            departure.TenantId = CurrentTenant.Id;
            departure = await _departureRepository.InsertAsync(departure, autoSave: true);
            return ObjectMapper.Map<Departure, DepartureDto>(departure);
        }

        [Authorize(CcmPermissions.Departures.Edit)]
        public virtual async Task<DepartureDto> UpdateAsync(Guid id, DepartureUpdateDto input)
        {
            if (input.Partner == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Partner"]]);
            }
            if (input.SeasonName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["DepartureSeason"]]);
            }

            var departure = await _departureRepository.GetAsync(id);
            ObjectMapper.Map(input, departure);
            departure = await _departureRepository.UpdateAsync(departure, autoSave: true);
            return ObjectMapper.Map<Departure, DepartureDto>(departure);
        }
    }
}