using Ccm.Ships;
using Ccm.Itineraries;

using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Cruises
{
    public class CruiseWithNavigationPropertiesDto
    {
        public CruiseDto Cruise { get; set; }

        public ShipDto Ship { get; set; }
        public ItineraryDto Itinerary { get; set; }

    }
}