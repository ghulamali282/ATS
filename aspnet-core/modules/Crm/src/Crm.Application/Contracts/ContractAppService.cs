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
using Crm.Permissions;
using Crm.Contracts;

namespace Crm.Contracts
{

    [Authorize(CrmPermissions.Contracts.Default)]
    public class ContractsAppService : ApplicationService, IContractsAppService
    {
        private readonly IContractRepository _contractRepository;

        public ContractsAppService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
        }

        public virtual async Task<PagedResultDto<ContractDto>> GetListAsync(GetContractsInput input)
        {
            var totalCount = await _contractRepository.GetCountAsync(input.FilterText, input.OperatorName, input.SeasonMin, input.SeasonMax, input.IsEnabledAgent, input.IsEnabledOperator);
            var items = await _contractRepository.GetListAsync(input.FilterText, input.OperatorName, input.SeasonMin, input.SeasonMax, input.IsEnabledAgent, input.IsEnabledOperator, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ContractDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Contract>, List<ContractDto>>(items)
            };
        }

        public virtual async Task<ContractDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Contract, ContractDto>(await _contractRepository.GetAsync(id));
        }

        [Authorize(CrmPermissions.Contracts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _contractRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.Contracts.Create)]
        public virtual async Task<ContractDto> CreateAsync(ContractCreateDto input)
        {

            var contract = ObjectMapper.Map<ContractCreateDto, Contract>(input);
            contract.TenantId = CurrentTenant.Id;
            contract = await _contractRepository.InsertAsync(contract, autoSave: true);
            return ObjectMapper.Map<Contract, ContractDto>(contract);
        }

        [Authorize(CrmPermissions.Contracts.Edit)]
        public virtual async Task<ContractDto> UpdateAsync(Guid id, ContractUpdateDto input)
        {

            var contract = await _contractRepository.GetAsync(id);
            ObjectMapper.Map(input, contract);
            contract = await _contractRepository.UpdateAsync(contract, autoSave: true);
            return ObjectMapper.Map<Contract, ContractDto>(contract);
        }
    }
}