using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Crm.Clients
{
    public interface IClientsAppService : IApplicationService
    {
        Task<PagedResultDto<ClientDto>> GetListAsync(GetClientsInput input);

        Task<ClientDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ClientDto> CreateAsync(ClientCreateDto input);

        Task<ClientDto> UpdateAsync(Guid id, ClientUpdateDto input);
    }
}