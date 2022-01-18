using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.BookingStatuses
{
    public class BookingStatusCreateDto
    {
        [Required]
        public string StatusColor { get; set; }
        public Guid BookingStatusName { get; set; }
    }
}