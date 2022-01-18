using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Itineraries
{
    public class ItineraryDto : EntityDto<Guid>
    {
        public string ItineraryNameString { get; set; }
        public string ItineraryCode { get; set; }
        public string GoogleMapLink { get; set; }
        public int Duration { get; set; }
        public bool ExtendedItinerary { get; set; }
        public Guid? Marina { get; set; }
        public string EmbarcationLatitude { get; set; }
        public string EmbarcationLongitude { get; set; }
        public string DisembarkationLatitude { get; set; }
        public string DisembarkationLongitude { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public bool TransferIncluded { get; set; }
        public string Video { get; set; }
        public int RequestDuration { get; set; }
        public int OptionDuration { get; set; }
        public Guid OperatorName { get; set; }
        public Guid Themes { get; set; }
        public Guid Boarding { get; set; }
        public Guid AgePolicyId { get; set; }
        public Guid EmbarcationPort { get; set; }
        public Guid DisembarkationPort { get; set; }
        public Guid CancellationPolicy { get; set; }
        public Guid PaymentPolicy { get; set; }
        public Guid ItineraryName { get; set; }
    }
}