using Ccm.Partners;
using Ccm.MasterDatas;
using Ccm.MasterDatas;
using Ccm.AgePolicies;
using Ccm.Destinations;
using Ccm.Destinations;
using Ccm.CancellationPolicies;
using Ccm.PaymentPolicies;
using Ccm.MasterDatas;

namespace Ccm.Itineraries
{
    public class ItineraryWithNavigationProperties
    {
        public Itinerary Itinerary { get; set; }

        public Partner Partner { get; set; }
        public MasterData MasterData { get; set; }
        public MasterData MasterData1 { get; set; }
        public AgePolicy AgePolicy { get; set; }
        public Destination Destination { get; set; }
        public Destination Destination1 { get; set; }
        public CancellationPolicy CancellationPolicy { get; set; }
        public PaymentPolicy PaymentPolicy { get; set; }
        public MasterData MasterData2 { get; set; }
        
    }
}