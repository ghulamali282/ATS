using Volo.Abp.Application.Dtos;
using System;

namespace Amm.BookingStatuses
{
    public class GetBookingStatusesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string StatusColor { get; set; }
        public Guid? BookingStatusName { get; set; }

        public GetBookingStatusesInput()
        {

        }
    }
}