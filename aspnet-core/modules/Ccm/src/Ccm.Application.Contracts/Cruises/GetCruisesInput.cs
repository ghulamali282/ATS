using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.Cruises
{
    public class GetCruisesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public int? SeasonMin { get; set; }
        public int? SeasonMax { get; set; }
        public bool? CruiseEnabled { get; set; }
        public bool? Featured { get; set; }
        public bool? FreeInternetOnBoard { get; set; }
        public bool? InternetOnBoard { get; set; }
        public string Video { get; set; }
        public bool? B2B { get; set; }
        public bool? B2C { get; set; }
        public bool? B2B_Agent { get; set; }
        public bool? B2C_Agent { get; set; }
        public Guid? CruiseDescriptions { get; set; }
        public Guid? ShipAmenities { get; set; }
        public Guid? ShipArticles { get; set; }
        public Guid? ShipPhotos { get; set; }
        public Guid? CabinAmenities { get; set; }
        public Guid? CabinArticles { get; set; }
        public Guid? CabinPhotos { get; set; }
        public Guid? Ship { get; set; }
        public Guid? Itinerary { get; set; }

        public GetCruisesInput()
        {

        }
    }
}