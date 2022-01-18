using Ccm.Ships;
using Ccm.Itineraries;

namespace Ccm.Cruises
{
    public class CruiseWithNavigationProperties
    {
        public Cruise Cruise { get; set; }

        public Ship Ship { get; set; }
        public Itinerary Itinerary { get; set; }
        
    }
}