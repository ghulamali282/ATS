using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.Partners
{
    public interface IPartnersAppService : IApplicationService
    {
        Task<PagedResultDto<PartnerWithNavigationPropertiesDto>> GetListAsync(GetPartnersInput input);

        Task<PartnerWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<PartnerDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<string>>> GetCountryLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<PartnerDto> CreateAsync(PartnerCreateDto input);

        Task<PartnerDto> UpdateAsync(Guid id, PartnerUpdateDto input);
    }
}