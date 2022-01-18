using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.Countries
{
    public class CountryUpdateDto
    {
        [Required]
        [StringLength(CountryConsts.CountryNameMaxLength)]
        public string CountryName { get; set; }
        [Required]
        [StringLength(CountryConsts.CultureNameMaxLength)]
        public string CultureName { get; set; }
    }
}