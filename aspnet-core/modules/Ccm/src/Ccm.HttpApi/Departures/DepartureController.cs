using Ccm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.Departures;

namespace Ccm.Departures
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("Departure")]
    [Route("api/ccm/departures")]
    public class DepartureController : AbpController, IDeparturesAppService
    {
        private readonly IDeparturesAppService _departuresAppService;

        public DepartureController(IDeparturesAppService departuresAppService)
        {
            _departuresAppService = departuresAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<DepartureWithNavigationPropertiesDto>> GetListAsync(GetDeparturesInput input)
        {
            return _departuresAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<DepartureWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _departuresAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<DepartureDto> GetAsync(Guid id)
        {
            return _departuresAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("partner-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetPartnerLookupAsync(LookupRequestDto input)
        {
            return _departuresAppService.GetPartnerLookupAsync(input);
        }

        [HttpGet]
        [Route("departure-season-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetDepartureSeasonLookupAsync(LookupRequestDto input)
        {
            return _departuresAppService.GetDepartureSeasonLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<DepartureDto> CreateAsync(DepartureCreateDto input)
        {
            return _departuresAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<DepartureDto> UpdateAsync(Guid id, DepartureUpdateDto input)
        {
            return _departuresAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _departuresAppService.DeleteAsync(id);
        }
    }
}