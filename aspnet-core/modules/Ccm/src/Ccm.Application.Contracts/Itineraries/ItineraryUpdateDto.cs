using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.Itineraries
{
    public class ItineraryUpdateDto
    {
        [Required]
        public string ItineraryNameString { get; set; }
        [Required]
        [StringLength(ItineraryConsts.ItineraryCodeMaxLength)]
        public string ItineraryCode { get; set; }
        [StringLength(ItineraryConsts.GoogleMapLinkMaxLength)]
        public string GoogleMapLink { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public bool ExtendedItinerary { get; set; }
        public Guid? Marina { get; set; }
        [Required]
        [StringLength(ItineraryConsts.EmbarcationLatitudeMaxLength)]
        public string EmbarcationLatitude { get; set; }
        [Required]
        [StringLength(ItineraryConsts.EmbarcationLongitudeMaxLength)]
        public string EmbarcationLongitude { get; set; }
        [Required]
        [StringLength(ItineraryConsts.DisembarkationLatitudeMaxLength)]
        public string DisembarkationLatitude { get; set; }
        [Required]
        [StringLength(ItineraryConsts.DisembarkationLongitudeMaxLength)]
        public string DisembarkationLongitude { get; set; }
        [Required]
        [StringLength(ItineraryConsts.CheckInTimeMaxLength)]
        public string CheckInTime { get; set; }
        [Required]
        [StringLength(ItineraryConsts.CheckOutTimeMaxLength)]
        public string CheckOutTime { get; set; }
        [Required]
        public bool TransferIncluded { get; set; }
        [StringLength(ItineraryConsts.VideoMaxLength)]
        public string Video { get; set; }
        [Required]
        public int RequestDuration { get; set; }
        [Required]
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