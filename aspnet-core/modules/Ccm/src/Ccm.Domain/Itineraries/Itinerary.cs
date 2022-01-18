using Ccm.Partners;
using Ccm.MasterDatas;
using Ccm.AgePolicies;
using Ccm.Destinations;
using Ccm.CancellationPolicies;
using Ccm.PaymentPolicies;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.Itineraries
{
    public class Itinerary : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string ItineraryNameString { get; set; }

        [NotNull]
        public virtual string ItineraryCode { get; set; }

        [CanBeNull]
        public virtual string GoogleMapLink { get; set; }

        public virtual int Duration { get; set; }

        public virtual bool ExtendedItinerary { get; set; }

        public virtual Guid? Marina { get; set; }

        [NotNull]
        public virtual string EmbarcationLatitude { get; set; }

        [NotNull]
        public virtual string EmbarcationLongitude { get; set; }

        [NotNull]
        public virtual string DisembarkationLatitude { get; set; }

        [NotNull]
        public virtual string DisembarkationLongitude { get; set; }

        [NotNull]
        public virtual string CheckInTime { get; set; }

        [NotNull]
        public virtual string CheckOutTime { get; set; }

        public virtual bool TransferIncluded { get; set; }

        [CanBeNull]
        public virtual string Video { get; set; }

        public virtual int RequestDuration { get; set; }

        public virtual int OptionDuration { get; set; }
        public Guid OperatorName { get; set; }
        public Guid Themes { get; set; }
        public Guid Boarding { get; set; }
        public Guid AgePolicyId { get; set; }
        public Guid EmbarcationPort { get; set; }
        public Guid DisembarkationPort { get; set; }
        public Guid CancellationPolicy { get; set; }
        public Guid PaymentPolicy { get; set; }
        public Guid ItineraryName { get; set; }

        public Itinerary()
        {

        }

        public Itinerary(Guid id, string itineraryNameString, Guid operatorName, Guid themes, Guid boarding, Guid agePolicyId, Guid embarcationPort, Guid disembarkationPort, Guid cancellationPolicy, Guid paymentPolicy, Guid itineraryName, string itineraryCode, int duration, bool extendedItinerary, string embarcationLatitude, string embarcationLongitude, string disembarkationLatitude, string disembarkationLongitude, string checkInTime, string checkOutTime, bool transferIncluded, int requestDuration, int optionDuration, string googleMapLink = null, Guid? marina = null, string video = null)
        {
            Id = id;
            Check.NotNull(itineraryNameString, nameof(itineraryNameString));
            Check.NotNull(itineraryCode, nameof(itineraryCode));
            Check.Length(itineraryCode, nameof(itineraryCode), ItineraryConsts.ItineraryCodeMaxLength, 0);
            Check.NotNull(embarcationLatitude, nameof(embarcationLatitude));
            Check.Length(embarcationLatitude, nameof(embarcationLatitude), ItineraryConsts.EmbarcationLatitudeMaxLength, 0);
            Check.NotNull(embarcationLongitude, nameof(embarcationLongitude));
            Check.Length(embarcationLongitude, nameof(embarcationLongitude), ItineraryConsts.EmbarcationLongitudeMaxLength, 0);
            Check.NotNull(disembarkationLatitude, nameof(disembarkationLatitude));
            Check.Length(disembarkationLatitude, nameof(disembarkationLatitude), ItineraryConsts.DisembarkationLatitudeMaxLength, 0);
            Check.NotNull(disembarkationLongitude, nameof(disembarkationLongitude));
            Check.Length(disembarkationLongitude, nameof(disembarkationLongitude), ItineraryConsts.DisembarkationLongitudeMaxLength, 0);
            Check.NotNull(checkInTime, nameof(checkInTime));
            Check.Length(checkInTime, nameof(checkInTime), ItineraryConsts.CheckInTimeMaxLength, 0);
            Check.NotNull(checkOutTime, nameof(checkOutTime));
            Check.Length(checkOutTime, nameof(checkOutTime), ItineraryConsts.CheckOutTimeMaxLength, 0);
            Check.Length(googleMapLink, nameof(googleMapLink), ItineraryConsts.GoogleMapLinkMaxLength, 0);
            Check.Length(video, nameof(video), ItineraryConsts.VideoMaxLength, 0);
            ItineraryNameString = itineraryNameString;
            ItineraryCode = itineraryCode;
            Duration = duration;
            ExtendedItinerary = extendedItinerary;
            EmbarcationLatitude = embarcationLatitude;
            EmbarcationLongitude = embarcationLongitude;
            DisembarkationLatitude = disembarkationLatitude;
            DisembarkationLongitude = disembarkationLongitude;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
            TransferIncluded = transferIncluded;
            RequestDuration = requestDuration;
            OptionDuration = optionDuration;
            GoogleMapLink = googleMapLink;
            Marina = marina;
            Video = video;
            OperatorName = operatorName;
            Themes = themes;
            Boarding = boarding;
            AgePolicyId = agePolicyId;
            EmbarcationPort = embarcationPort;
            DisembarkationPort = disembarkationPort;
            CancellationPolicy = cancellationPolicy;
            PaymentPolicy = paymentPolicy;
            ItineraryName = itineraryName;
        }
    }
}