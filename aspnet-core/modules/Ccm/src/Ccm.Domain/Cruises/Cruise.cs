using Ccm.Ships;
using Ccm.Itineraries;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.Cruises
{
    public class Cruise : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual int Season { get; set; }

        public virtual bool CruiseEnabled { get; set; }

        public virtual bool Featured { get; set; }

        public virtual bool FreeInternetOnBoard { get; set; }

        public virtual bool InternetOnBoard { get; set; }

        [CanBeNull]
        public virtual string Video { get; set; }

        public virtual bool B2B { get; set; }

        public virtual bool B2C { get; set; }

        public virtual bool B2B_Agent { get; set; }

        public virtual bool B2C_Agent { get; set; }

        public virtual Guid? CruiseDescriptions { get; set; }

        public virtual Guid? ShipAmenities { get; set; }

        public virtual Guid? ShipArticles { get; set; }

        public virtual Guid? ShipPhotos { get; set; }

        public virtual Guid? CabinAmenities { get; set; }

        public virtual Guid? CabinArticles { get; set; }

        public virtual Guid? CabinPhotos { get; set; }
        public Guid Ship { get; set; }
        public Guid Itinerary { get; set; }

        public Cruise()
        {

        }

        public Cruise(Guid id, Guid ship, Guid itinerary, int season, bool cruiseEnabled, bool featured, bool freeInternetOnBoard, bool internetOnBoard, bool b2B, bool b2C, bool b2B_Agent, bool b2C_Agent, string video = null, Guid? cruiseDescriptions = null, Guid? shipAmenities = null, Guid? shipArticles = null, Guid? shipPhotos = null, Guid? cabinAmenities = null, Guid? cabinArticles = null, Guid? cabinPhotos = null)
        {
            Id = id;
            Check.Length(video, nameof(video), CruiseConsts.VideoMaxLength, 0);
            Season = season;
            CruiseEnabled = cruiseEnabled;
            Featured = featured;
            FreeInternetOnBoard = freeInternetOnBoard;
            InternetOnBoard = internetOnBoard;
            B2B = b2B;
            B2C = b2C;
            B2B_Agent = b2B_Agent;
            B2C_Agent = b2C_Agent;
            Video = video;
            CruiseDescriptions = cruiseDescriptions;
            ShipAmenities = shipAmenities;
            ShipArticles = shipArticles;
            ShipPhotos = shipPhotos;
            CabinAmenities = cabinAmenities;
            CabinArticles = cabinArticles;
            CabinPhotos = cabinPhotos;
            Ship = ship;
            Itinerary = itinerary;
        }
    }
}