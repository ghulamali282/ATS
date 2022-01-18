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
using Amm.Partners;

namespace Amm.Partners
{

    [Authorize(AmmPermissions.Partners.Default)]
    public class PartnersAppService : ApplicationService, IPartnersAppService
    {
        private readonly IPartnerRepository _partnerRepository;

        public PartnersAppService(IPartnerRepository partnerRepository)
        {
            _partnerRepository = partnerRepository;
        }

        public virtual async Task<PagedResultDto<PartnerDto>> GetListAsync(GetPartnersInput input)
        {
            var totalCount = await _partnerRepository.GetCountAsync(input.FilterText, input.PartnerName);
            var items = await _partnerRepository.GetListAsync(input.FilterText, input.PartnerName, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PartnerDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Partner>, List<PartnerDto>>(items)
            };
        }

        public virtual async Task<PartnerDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Partner, PartnerDto>(await _partnerRepository.GetAsync(id));
        }

        [Authorize(AmmPermissions.Partners.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _partnerRepository.DeleteAsync(id);
        }

        [Authorize(AmmPermissions.Partners.Create)]
        public virtual async Task<PartnerDto> CreateAsync(PartnerCreateDto input)
        {

            var partner = ObjectMapper.Map<PartnerCreateDto, Partner>(input);

            partner = await _partnerRepository.InsertAsync(partner, autoSave: true);
            return ObjectMapper.Map<Partner, PartnerDto>(partner);
        }

        [Authorize(AmmPermissions.Partners.Edit)]
        public virtual async Task<PartnerDto> UpdateAsync(Guid id, PartnerUpdateDto input)
        {

            var partner = await _partnerRepository.GetAsync(id);
            ObjectMapper.Map(input, partner);
            partner = await _partnerRepository.UpdateAsync(partner, autoSave: true);
            return ObjectMapper.Map<Partner, PartnerDto>(partner);
        }
    }
}