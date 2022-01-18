using Amm.Shared;
using Amm.Destinations;
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
using Amm.Marinas;

namespace Amm.Marinas
{

    [Authorize(AmmPermissions.Marinas.Default)]
    public class MarinasAppService : ApplicationService, IMarinasAppService
    {
        private readonly IMarinaRepository _marinaRepository;
        private readonly IRepository<MasterData, Guid> _masterDataRepository;
        private readonly IRepository<Destination, Guid> _destinationRepository;

        public MarinasAppService(IMarinaRepository marinaRepository, IRepository<MasterData, Guid> masterDataRepository, IRepository<Destination, Guid> destinationRepository)
        {
            _marinaRepository = marinaRepository; _masterDataRepository = masterDataRepository;
            _destinationRepository = destinationRepository;
        }

        public virtual async Task<PagedResultDto<MarinaWithNavigationPropertiesDto>> GetListAsync(GetMarinasInput input)
        {
            var totalCount = await _marinaRepository.GetCountAsync(input.FilterText, input.MarinaNameString, input.Latitude, input.Longitude, input.MarinaName, input.Destination);
            var items = await _marinaRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.MarinaNameString, input.Latitude, input.Longitude, input.MarinaName, input.Destination, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MarinaWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MarinaWithNavigationProperties>, List<MarinaWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<MarinaWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<MarinaWithNavigationProperties, MarinaWithNavigationPropertiesDto>
                (await _marinaRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<MarinaDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Marina, MarinaDto>(await _marinaRepository.GetAsync(id));
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

        [Authorize(AmmPermissions.Marinas.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _marinaRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.Marinas.Create)]
        public virtual async Task<MarinaDto> CreateAsync(MarinaCreateDto input)
        {
            if (input.MarinaName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }
            if (input.Destination == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Destination"]]);
            }

            var marina = ObjectMapper.Map<MarinaCreateDto, Marina>(input);

            marina = await _marinaRepository.InsertAsync(marina, autoSave: true);
            return ObjectMapper.Map<Marina, MarinaDto>(marina);
        }

        [Authorize(AmmPermissions.Marinas.Edit)]
        public virtual async Task<MarinaDto> UpdateAsync(Guid id, MarinaUpdateDto input)
        {
            if (input.MarinaName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["MasterData"]]);
            }
            if (input.Destination == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Destination"]]);
            }

            var marina = await _marinaRepository.GetAsync(id);
            ObjectMapper.Map(input, marina);
            marina = await _marinaRepository.UpdateAsync(marina, autoSave: true);
            return ObjectMapper.Map<Marina, MarinaDto>(marina);
        }
    }
}