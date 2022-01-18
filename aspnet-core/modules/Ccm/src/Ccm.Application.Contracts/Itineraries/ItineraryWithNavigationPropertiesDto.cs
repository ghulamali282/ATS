using Ccm.Partners;
using Ccm.MasterDatas;
using Ccm.MasterDatas;
using Ccm.AgePolicies;
using Ccm.Destinations;
using Ccm.Destinations;
using Ccm.CancellationPolicies;
using Ccm.PaymentPolicies;
using Ccm.MasterDatas;

using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Itineraries
{
    public class ItineraryWithNavigationPropertiesDto
    {
        public ItineraryDto Itinerary { get; set; }

        public PartnerDto Partner { get; set; }
        public MasterDataDto MasterData { get; set; }
        public MasterDataDto MasterData1 { get; set; }
        public AgePolicyDto AgePolicy { get; set; }
        public DestinationDto Destination { get; set; }
        public DestinationDto Destination1 { get; set; }
        public CancellationPolicyDto CancellationPolicy { get; set; }
        public PaymentPolicyDto PaymentPolicy { get; set; }
        public MasterDataDto MasterData2 { get; set; }

    }
}