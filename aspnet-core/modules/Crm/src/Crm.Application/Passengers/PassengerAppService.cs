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
using Crm.Passengers;

namespace Crm.Passengers
{

    [Authorize(CrmPermissions.Passengers.Default)]
    public class PassengersAppService : ApplicationService, IPassengersAppService
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengersAppService(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public virtual async Task<PagedResultDto<PassengerDto>> GetListAsync(GetPassengersInput input)
        {
            var totalCount = await _passengerRepository.GetCountAsync(input.FilterText, input.Reservation, input.ReservationDetail, input.ReservationHolder, input.Title, input.FirstName, input.LastName, input.Country, input.AgePolicyDetail, input.PassengerDOBMin, input.PassengerDOBMax, input.DocumentType, input.DocumentNo, input.IssueDateMin, input.IssueDateMax, input.ExpirationMin, input.ExpirationMax, input.PassengerNote, input.ClientNoMin, input.ClientNoMax, input.Reduction);
            var items = await _passengerRepository.GetListAsync(input.FilterText, input.Reservation, input.ReservationDetail, input.ReservationHolder, input.Title, input.FirstName, input.LastName, input.Country, input.AgePolicyDetail, input.PassengerDOBMin, input.PassengerDOBMax, input.DocumentType, input.DocumentNo, input.IssueDateMin, input.IssueDateMax, input.ExpirationMin, input.ExpirationMax, input.PassengerNote, input.ClientNoMin, input.ClientNoMax, input.Reduction, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<PassengerDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Passenger>, List<PassengerDto>>(items)
            };
        }

        public virtual async Task<PassengerDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Passenger, PassengerDto>(await _passengerRepository.GetAsync(id));
        }

        [Authorize(CrmPermissions.Passengers.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _passengerRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.Passengers.Create)]
        public virtual async Task<PassengerDto> CreateAsync(PassengerCreateDto input)
        {

            var passenger = ObjectMapper.Map<PassengerCreateDto, Passenger>(input);
            passenger.TenantId = CurrentTenant.Id;
            passenger = await _passengerRepository.InsertAsync(passenger, autoSave: true);
            return ObjectMapper.Map<Passenger, PassengerDto>(passenger);
        }

        [Authorize(CrmPermissions.Passengers.Edit)]
        public virtual async Task<PassengerDto> UpdateAsync(Guid id, PassengerUpdateDto input)
        {

            var passenger = await _passengerRepository.GetAsync(id);
            ObjectMapper.Map(input, passenger);
            passenger = await _passengerRepository.UpdateAsync(passenger, autoSave: true);
            return ObjectMapper.Map<Passenger, PassengerDto>(passenger);
        }
    }
}