using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.Cruises
{
    public class CruiseCreateDto
    {
        [Required]
        public int Season { get; set; }
        [Required]
        public bool CruiseEnabled { get; set; }
        [Required]
        public bool Featured { get; set; }
        [Required]
        public bool FreeInternetOnBoard { get; set; }
        [Required]
        public bool InternetOnBoard { get; set; }
        [StringLength(CruiseConsts.VideoMaxLength)]
        public string Video { get; set; }
        [Required]
        public bool B2B { get; set; }
        [Required]
        public bool B2C { get; set; }
        [Required]
        public bool B2B_Agent { get; set; }
        [Required]
        public bool B2C_Agent { get; set; }
        public Guid? CruiseDescriptions { get; set; }
        public Guid? ShipAmenities { get; set; }
        public Guid? ShipArticles { get; set; }
        public Guid? ShipPhotos { get; set; }
        public Guid? CabinAmenities { get; set; }
        public Guid? CabinArticles { get; set; }
        public Guid? CabinPhotos { get; set; }
        public Guid Ship { get; set; }
        public Guid Itinerary { get; set; }
    }
}