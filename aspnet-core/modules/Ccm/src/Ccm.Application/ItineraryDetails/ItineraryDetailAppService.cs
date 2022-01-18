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
using Ccm.ItineraryDetails;

namespace Ccm.ItineraryDetails
{

    [Authorize(CcmPermissions.ItineraryDetails.Default)]
    public class ItineraryDetailsAppService : ApplicationService, IItineraryDetailsAppService
    {
        private readonly IItineraryDetailRepository _itineraryDetailRepository;

        public ItineraryDetailsAppService(IItineraryDetailRepository itineraryDetailRepository)
        {
            _itineraryDetailRepository = itineraryDetailRepository;
        }

        public virtual async Task<PagedResultDto<ItineraryDetailDto>> GetListAsync(GetItineraryDetailsInput input)
        {
            var totalCount = await _itineraryDetailRepository.GetCountAsync(input.FilterText, input.Itinerary, input.Name, input.DayMin, input.DayMax, input.Ports, input.AlternativePorts, input.WelcomeDrink, input.WelcomeSnack, input.Breakfast, input.Brunch, input.Lunch, input.AfternoonSnack, input.Dinner, input.CaptainDinner, input.LiveMusic, input.WineTasting, input.OvernightOnAnchor, input.OvernightAtMarina);
            var items = await _itineraryDetailRepository.GetListAsync(input.FilterText, input.Itinerary, input.Name, input.DayMin, input.DayMax, input.Ports, input.AlternativePorts, input.WelcomeDrink, input.WelcomeSnack, input.Breakfast, input.Brunch, input.Lunch, input.AfternoonSnack, input.Dinner, input.CaptainDinner, input.LiveMusic, input.WineTasting, input.OvernightOnAnchor, input.OvernightAtMarina, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ItineraryDetailDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ItineraryDetail>, List<ItineraryDetailDto>>(items)
            };
        }

        public virtual async Task<ItineraryDetailDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ItineraryDetail, ItineraryDetailDto>(await _itineraryDetailRepository.GetAsync(id));
        }

        [Authorize(CcmPermissions.ItineraryDetails.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _itineraryDetailRepository.DeleteAsync(id);
        }

        [Authorize(CcmPermissions.ItineraryDetails.Create)]
        public virtual async Task<ItineraryDetailDto> CreateAsync(ItineraryDetailCreateDto input)
        {

            var itineraryDetail = ObjectMapper.Map<ItineraryDetailCreateDto, ItineraryDetail>(input);

            itineraryDetail = await _itineraryDetailRepository.InsertAsync(itineraryDetail, autoSave: true);
            return ObjectMapper.Map<ItineraryDetail, ItineraryDetailDto>(itineraryDetail);
        }

        [Authorize(CcmPermissions.ItineraryDetails.Edit)]
        public virtual async Task<ItineraryDetailDto> UpdateAsync(Guid id, ItineraryDetailUpdateDto input)
        {

            var itineraryDetail = await _itineraryDetailRepository.GetAsync(id);
            ObjectMapper.Map(input, itineraryDetail);
            itineraryDetail = await _itineraryDetailRepository.UpdateAsync(itineraryDetail, autoSave: true);
            return ObjectMapper.Map<ItineraryDetail, ItineraryDetailDto>(itineraryDetail);
        }
    }
}