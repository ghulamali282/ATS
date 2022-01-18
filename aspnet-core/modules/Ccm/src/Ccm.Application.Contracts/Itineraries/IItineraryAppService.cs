using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Ccm.Itineraries
{
    public interface IItinerariesAppService : IApplicationService
    {
        Task<PagedResultDto<ItineraryWithNavigationPropertiesDto>> GetListAsync(GetItinerariesInput input);

        Task<ItineraryWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<ItineraryDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetAgePolicyLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetDestinationLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetCancellationPolicyLookupAsync(LookupRequestDto input);

        Task<PagedResultDto<LookupDto<Guid>>> GetPaymentPolicyLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<ItineraryDto> CreateAsync(ItineraryCreateDto input);

        Task<ItineraryDto> UpdateAsync(Guid id, ItineraryUpdateDto input);
    }
}