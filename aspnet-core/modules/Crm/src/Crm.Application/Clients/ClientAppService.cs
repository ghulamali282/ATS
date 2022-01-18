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
using Crm.Clients;

namespace Crm.Clients
{

    [Authorize(CrmPermissions.Clients.Default)]
    public class ClientsAppService : ApplicationService, IClientsAppService
    {
        private readonly IClientRepository _clientRepository;

        public ClientsAppService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public virtual async Task<PagedResultDto<ClientDto>> GetListAsync(GetClientsInput input)
        {
            var totalCount = await _clientRepository.GetCountAsync(input.FilterText, input.Title, input.FirstName, input.SecondName, input.Gender, input.ClientDOBMin, input.ClientDOBMax, input.AgePolicy, input.Email, input.EmailConfirmed, input.Country, input.Nacionality, input.State, input.ZipCode, input.City, input.CellPhone, input.CellPhoneConfirmed, input.DocumentType, input.DocumentNo, input.IssueDateMin, input.IssueDateMax, input.ExpirationMin, input.ExpirationMax, input.MailingList);
            var items = await _clientRepository.GetListAsync(input.FilterText, input.Title, input.FirstName, input.SecondName, input.Gender, input.ClientDOBMin, input.ClientDOBMax, input.AgePolicy, input.Email, input.EmailConfirmed, input.Country, input.Nacionality, input.State, input.ZipCode, input.City, input.CellPhone, input.CellPhoneConfirmed, input.DocumentType, input.DocumentNo, input.IssueDateMin, input.IssueDateMax, input.ExpirationMin, input.ExpirationMax, input.MailingList, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ClientDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Client>, List<ClientDto>>(items)
            };
        }

        public virtual async Task<ClientDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Client, ClientDto>(await _clientRepository.GetAsync(id));
        }

        [Authorize(CrmPermissions.Clients.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _clientRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.Clients.Create)]
        public virtual async Task<ClientDto> CreateAsync(ClientCreateDto input)
        {

            var client = ObjectMapper.Map<ClientCreateDto, Client>(input);
            client.TenantId = CurrentTenant.Id;
            client = await _clientRepository.InsertAsync(client, autoSave: true);
            return ObjectMapper.Map<Client, ClientDto>(client);
        }

        [Authorize(CrmPermissions.Clients.Edit)]
        public virtual async Task<ClientDto> UpdateAsync(Guid id, ClientUpdateDto input)
        {

            var client = await _clientRepository.GetAsync(id);
            ObjectMapper.Map(input, client);
            client = await _clientRepository.UpdateAsync(client, autoSave: true);
            return ObjectMapper.Map<Client, ClientDto>(client);
        }
    }
}