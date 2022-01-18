using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.DepartureSeasons;

namespace Ccm.DepartureSeasons
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("DepartureSeason")]
    [Route("api/ccm/departure-seasons")]
    public class DepartureSeasonController : AbpController, IDepartureSeasonsAppService
    {
        private readonly IDepartureSeasonsAppService _departureSeasonsAppService;

        public DepartureSeasonController(IDepartureSeasonsAppService departureSeasonsAppService)
        {
            _departureSeasonsAppService = departureSeasonsAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<DepartureSeasonWithNavigationPropertiesDto>> GetListAsync(GetDepartureSeasonsInput input)
        {
            return _departureSeasonsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<DepartureSeasonWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _departureSeasonsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<DepartureSeasonDto> GetAsync(Guid id)
        {
            return _departureSeasonsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("partner-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input)
        {
            return _departureSeasonsAppService.GetPartnerLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<DepartureSeasonDto> CreateAsync(DepartureSeasonCreateDto input)
        {
            return _departureSeasonsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<DepartureSeasonDto> UpdateAsync(Guid id, DepartureSeasonUpdateDto input)
        {
            return _departureSeasonsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _departureSeasonsAppService.DeleteAsync(id);
        }
    }
}