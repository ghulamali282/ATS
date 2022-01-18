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
using Ccm.Permissions;
using Ccm.Destinations;

namespace Ccm.Destinations
{

    [Authorize(CcmPermissions.Destinations.Default)]
    public class DestinationsAppService : ApplicationService, IDestinationsAppService
    {
        private readonly IDestinationRepository _destinationRepository;

        public DestinationsAppService(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public virtual async Task<PagedResultDto<DestinationDto>> GetListAsync(GetDestinationsInput input)
        {
            var totalCount = await _destinationRepository.GetCountAsync(input.FilterText, input.City);
            var items = await _destinationRepository.GetListAsync(input.FilterText, input.City, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<DestinationDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Destination>, List<DestinationDto>>(items)
            };
        }

        public virtual async Task<DestinationDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Destination, DestinationDto>(await _destinationRepository.GetAsync(id));
        }

        [Authorize(CcmPermissions.Destinations.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _destinationRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.Destinations.Create)]
        public virtual async Task<DestinationDto> CreateAsync(DestinationCreateDto input)
        {

            var destination = ObjectMapper.Map<DestinationCreateDto, Destination>(input);
            destination.TenantId = CurrentTenant.Id;
            destination = await _destinationRepository.InsertAsync(destination, autoSave: true);
            return ObjectMapper.Map<Destination, DestinationDto>(destination);
        }

        [Authorize(CcmPermissions.Destinations.Edit)]
        public virtual async Task<DestinationDto> UpdateAsync(Guid id, DestinationUpdateDto input)
        {

            var destination = await _destinationRepository.GetAsync(id);
            ObjectMapper.Map(input, destination);
            destination = await _destinationRepository.UpdateAsync(destination, autoSave: true);
            return ObjectMapper.Map<Destination, DestinationDto>(destination);
        }
    }
}