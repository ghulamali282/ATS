using Ccm.Partners;
using Ccm.DepartureSeasons;

namespace Ccm.Departures
{
    public class DepartureWithNavigationProperties
    {
        public Departure Departure { get; set; }

        public Partner Partner { get; set; }
        public DepartureSeason DepartureSeason { get; set; }
        
    }
}