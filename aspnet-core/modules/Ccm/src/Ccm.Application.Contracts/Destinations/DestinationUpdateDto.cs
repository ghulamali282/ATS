using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.Destinations
{
    public class DestinationUpdateDto
    {
        [Required]
        [StringLength(DestinationConsts.CityMaxLength)]
        public string City { get; set; }
    }
}