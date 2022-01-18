using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.Destinations
{
    public class DestinationUpdateDto
    {
        [Required]
        [StringLength(DestinationConsts.CityMaxLength)]
        public string City { get; set; }
        [Required]
        [StringLength(DestinationConsts.CityLocalNameMaxLength)]
        public string CityLocalName { get; set; }
        [Required]
        public double latitude { get; set; }
        [Required]
        public double longitude { get; set; }
        [StringLength(DestinationConsts.VideoUrlMaxLength)]
        public string VideoUrl { get; set; }
        [Required]
        [StringLength(DestinationConsts.PlaceIdMaxLength)]
        public string PlaceId { get; set; }
        public string DestCountry { get; set; }
    }
}