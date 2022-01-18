using Ccm.Shared;
using Ccm.Countries;
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
using Ccm.Partners;

namespace Ccm.Partners
{

    [Authorize(CcmPermissions.Partners.Default)]
    public class PartnersAppService : ApplicationService, IPartnersAppService
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly IRepository<Country, string> _countryRepository;

        public PartnersAppService(IPartnerRepository partnerRepository, IRepository<Country, string> countryRepository)
        {
            _partnerRepository = partnerRepository; _countryRepository = countryRepository;
        }

        public virtual async Task<PagedResultDto<PartnerWithNavigationPropertiesDto>> GetListAsync(GetPartnersInput input)
        {
            var totalCount = await _partnerRepository.GetCountAsync(input.FilterText, input.PartnerName, input.Address, input.TaxNo, input.BookingEmail, input.BookingCellPhone, input.BookingEmailConfirmed, input.BookingPhoneConfirmed, input.Email, input.Phone, input.CountryName);
            var items = await _partnerRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.PartnerName, input.Address, input.TaxNo, input.BookingEmail, input.BookingCellPhone, input.BookingEmailConfirmed, input.BookingPhoneConfirmed, input.Email, input.Phone, input.CountryName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PartnerWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<PartnerWithNavigationProperties>, List<PartnerWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<PartnerWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<PartnerWithNavigationProperties, PartnerWithNavigationPropertiesDto>
                (await _partnerRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<PartnerDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Partner, PartnerDto>(await _partnerRepository.GetAsync(id));
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

        [Authorize(CcmPermissions.Partners.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _partnerRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.Partners.Create)]
        public virtual async Task<PartnerDto> CreateAsync(PartnerCreateDto input)
        {
            if (input.CountryName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }

            var partner = ObjectMapper.Map<PartnerCreateDto, Partner>(input);
            partner.TenantId = CurrentTenant.Id;
            partner = await _partnerRepository.InsertAsync(partner, autoSave: true);
            return ObjectMapper.Map<Partner, PartnerDto>(partner);
        }

        [Authorize(CcmPermissions.Partners.Edit)]
        public virtual async Task<PartnerDto> UpdateAsync(Guid id, PartnerUpdateDto input)
        {
            if (input.CountryName == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }

            var partner = await _partnerRepository.GetAsync(id);
            ObjectMapper.Map(input, partner);
            partner = await _partnerRepository.UpdateAsync(partner, autoSave: true);
            return ObjectMapper.Map<Partner, PartnerDto>(partner);
        }
    }
}