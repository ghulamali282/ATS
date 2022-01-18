using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Crm.Contracts;

namespace Crm.Contracts
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("Contract")]
    [Route("api/crm/contracts")]
    public class ContractController : AbpController, IContractsAppService
    {
        private readonly IContractsAppService _contractsAppService;

        public ContractController(IContractsAppService contractsAppService)
        {
            _contractsAppService = contractsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ContractDto>> GetListAsync(GetContractsInput input)
        {
            return _contractsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ContractDto> GetAsync(Guid id)
        {
            return _contractsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ContractDto> CreateAsync(ContractCreateDto input)
        {
            return _contractsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ContractDto> UpdateAsync(Guid id, ContractUpdateDto input)
        {
            return _contractsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _contractsAppService.DeleteAsync(id);
        }
    }
}