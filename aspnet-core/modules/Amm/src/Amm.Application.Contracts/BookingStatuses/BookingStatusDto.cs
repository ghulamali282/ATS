using System;
using Volo.Abp.Application.Dtos;

namespace Amm.BookingStatuses
{
    public class BookingStatusDto : EntityDto<int>
    {
        public string StatusColor { get; set; }
        public Guid BookingStatusName { get; set; }
    }
}