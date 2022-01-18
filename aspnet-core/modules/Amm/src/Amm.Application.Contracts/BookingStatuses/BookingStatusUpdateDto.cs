using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.BookingStatuses
{
    public class BookingStatusUpdateDto
    {
        [Required]
        public string StatusColor { get; set; }
        public Guid BookingStatusName { get; set; }
    }
}