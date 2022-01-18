using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.Contracts
{
    public interface IContractsAppService : IApplicationService
    {
        Task<PagedResultDto<ContractDto>> GetListAsync(GetContractsInput input);

        Task<ContractDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ContractDto> CreateAsync(ContractCreateDto input);

        Task<ContractDto> UpdateAsync(Guid id, ContractUpdateDto input);
    }
}