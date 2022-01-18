using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Crm.Clients;

namespace Crm.Clients
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("Client")]
    [Route("api/crm/clients")]
    public class ClientController : AbpController, IClientsAppService
    {
        private readonly IClientsAppService _clientsAppService;

        public ClientController(IClientsAppService clientsAppService)
        {
            _clientsAppService = clientsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ClientDto>> GetListAsync(GetClientsInput input)
        {
            return _clientsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ClientDto> GetAsync(Guid id)
        {
            return _clientsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ClientDto> CreateAsync(ClientCreateDto input)
        {
            return _clientsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ClientDto> UpdateAsync(Guid id, ClientUpdateDto input)
        {
            return _clientsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _clientsAppService.DeleteAsync(id);
        }
    }
}