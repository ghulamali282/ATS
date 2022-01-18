using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Ccm.Countries;

namespace Ccm.Countries
{
    [RemoteService(Name = "Ccm")]
    [Area("ccm")]
    [ControllerName("Country")]
    [Route("api/ccm/countries")]
    public class CountryController : AbpController, ICountriesAppService
    {
        private readonly ICountriesAppService _countriesAppService;

        public CountryController(ICountriesAppService countriesAppService)
        {
            _countriesAppService = countriesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CountryDto>> GetListAsync(GetCountriesInput input)
        {
            return _countriesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CountryDto> GetAsync(string id)
        {
            return _countriesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CountryDto> CreateAsync(CountryCreateDto input)
        {
            return _countriesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CountryDto> UpdateAsync(string id, CountryUpdateDto input)
        {
            return _countriesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(string id)
        {
            return _countriesAppService.DeleteAsync(id);
        }
    }
}