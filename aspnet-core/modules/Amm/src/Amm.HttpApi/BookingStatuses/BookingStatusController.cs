using Amm.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Amm.BookingStatuses;

namespace Amm.BookingStatuses
{
    [RemoteService(Name = "Amm")]
    [Area("amm")]
    [ControllerName("BookingStatus")]
    [Route("api/amm/booking-statuses")]
    public class BookingStatusController : AbpController, IBookingStatusesAppService
    {
        private readonly IBookingStatusesAppService _bookingStatusesAppService;

        public BookingStatusController(IBookingStatusesAppService bookingStatusesAppService)
        {
            _bookingStatusesAppService = bookingStatusesAppService;
        }

        [HttpGet]
        public Task<PagedResultDto<BookingStatusWithNavigationPropertiesDto>> GetListAsync(GetBookingStatusesInput input)
        {
            return _bookingStatusesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public Task<BookingStatusWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(int id)
        {
            return _bookingStatusesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<BookingStatusDto> GetAsync(int id)
        {
            return _bookingStatusesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("master-data-lookup")]
        public Task<PagedResultDto<LookupDto<Guid>>> GetMasterDataLookupAsync(LookupRequestDto input)
        {
            return _bookingStatusesAppService.GetMasterDataLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<BookingStatusDto> CreateAsync(BookingStatusCreateDto input)
        {
            return _bookingStatusesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<BookingStatusDto> UpdateAsync(int id, BookingStatusUpdateDto input)
        {
            return _bookingStatusesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _bookingStatusesAppService.DeleteAsync(id);
        }
    }
}