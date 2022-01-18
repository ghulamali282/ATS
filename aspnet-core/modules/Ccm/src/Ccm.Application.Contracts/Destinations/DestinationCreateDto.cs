using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.Destinations
{
    public class DestinationCreateDto
    {
        [Required]
        [StringLength(DestinationConsts.CityMaxLength)]
        public string City { get; set; }
    }
}