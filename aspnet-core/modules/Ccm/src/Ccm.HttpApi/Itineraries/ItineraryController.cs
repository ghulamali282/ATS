using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.Itineraries;

namespace Ccm.Itineraries
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("Itinerary")]
    [Route("api/ccm/itineraries")]
    public class ItineraryController : AbpController, IItinerariesAppService
    {
        private readonly IItinerariesAppService _itinerariesAppService;

        public ItineraryController(IItinerariesAppService itinerariesAppService)
        {
            _itinerariesAppService = itinerariesAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<ItineraryWithNavigationPropertiesDto>> GetListAsync(GetItinerariesInput input)
        {
            return _itinerariesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<ItineraryWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _itinerariesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ItineraryDto> GetAsync(Guid id)
        {
            return _itinerariesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("partner-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input)
        {
            return _itinerariesAppService.GetPartnerLookupAsync(input);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _itinerariesAppService.GetMasterDataLookupAsync(input);
        }

        [HttpGet]
        [Route("age-policy-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetAgePolicyLookupAsync(LookupRequestDto input)
        {
            return _itinerariesAppService.GetAgePolicyLookupAsync(input);
        }

        [HttpGet]
        [Route("destination-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetDestinationLookupAsync(LookupRequestDto input)
        {
            return _itinerariesAppService.GetDestinationLookupAsync(input);
        }

        [HttpGet]
        [Route("cancellation-policy-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetCancellationPolicyLookupAsync(LookupRequestDto input)
        {
            return _itinerariesAppService.GetCancellationPolicyLookupAsync(input);
        }

        [HttpGet]
        [Route("payment-policy-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetPaymentPolicyLookupAsync(LookupRequestDto input)
        {
            return _itinerariesAppService.GetPaymentPolicyLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<ItineraryDto> CreateAsync(ItineraryCreateDto input)
        {
            return _itinerariesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ItineraryDto> UpdateAsync(Guid id, ItineraryUpdateDto input)
        {
            return _itinerariesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _itinerariesAppService.DeleteAsync(id);
        }
    }
}