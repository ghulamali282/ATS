using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.Itineraries
{
    public class GetItinerariesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string ItineraryNameString { get; set; }
        public string ItineraryCode { get; set; }
        public string GoogleMapLink { get; set; }
        public int? DurationMin { get; set; }
        public int? DurationMax { get; set; }
        public bool? ExtendedItinerary { get; set; }
        public Guid? Marina { get; set; }
        public string EmbarcationLatitude { get; set; }
        public string EmbarcationLongitude { get; set; }
        public string DisembarkationLatitude { get; set; }
        public string DisembarkationLongitude { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public bool? TransferIncluded { get; set; }
        public string Video { get; set; }
        public int? RequestDurationMin { get; set; }
        public int? RequestDurationMax { get; set; }
        public int? OptionDurationMin { get; set; }
        public int? OptionDurationMax { get; set; }
        public Guid? OperatorName { get; set; }
        public Guid? Themes { get; set; }
        public Guid? Boarding { get; set; }
        public Guid? AgePolicyId { get; set; }
        public Guid? EmbarcationPort { get; set; }
        public Guid? DisembarkationPort { get; set; }
        public Guid? CancellationPolicy { get; set; }
        public Guid? PaymentPolicy { get; set; }
        public Guid? ItineraryName { get; set; }

        public GetItinerariesInput()
        {

        }
    }
}