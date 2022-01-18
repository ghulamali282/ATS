using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.CharterShips
{
    public class CharterShip : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid OperatorName { get; set; }

        public virtual int Season { get; set; }

        public virtual Guid? ShipNamePrefix { get; set; }

        public virtual Guid Ship { get; set; }

        public virtual Guid Itinerary { get; set; }

        [NotNull]
        public virtual string Tabs { get; set; }

        [CanBeNull]
        public virtual string Video { get; set; }

        public virtual bool Featured { get; set; }

        public virtual bool FreeInternetOnBoard { get; set; }

        public virtual bool Internet { get; set; }

        public virtual bool TransferIncluded { get; set; }

        public virtual bool EnabledByUser { get; set; }

        public virtual int? DisabledBySystem { get; set; }

        public virtual bool B2B { get; set; }

        public virtual bool B2C { get; set; }

        public virtual bool B2B_Agent { get; set; }

        public virtual bool B2C_Agent { get; set; }

        public virtual Guid? ShipAmenities { get; set; }

        public virtual Guid? ShipArticles { get; set; }

        public virtual Guid? ShipPhotos { get; set; }

        public virtual Guid? CabinAmenities { get; set; }

        public virtual Guid? CabinArticles { get; set; }

        public virtual Guid? CabinPhotos { get; set; }

        public CharterShip()
        {

        }

        public CharterShip(Guid id, Guid operatorName, int season, Guid ship, Guid itinerary, string tabs, bool featured, bool freeInternetOnBoard, bool internet, bool transferIncluded, bool enabledByUser, bool b2B, bool b2C, bool b2B_Agent, bool b2C_Agent, Guid? shipNamePrefix = null, string video = null, int? disabledBySystem = null, Guid? shipAmenities = null, Guid? shipArticles = null, Guid? shipPhotos = null, Guid? cabinAmenities = null, Guid? cabinArticles = null, Guid? cabinPhotos = null)
        {
            Id = id;
            Check.NotNull(tabs, nameof(tabs));
            Check.Length(tabs, nameof(tabs), CharterShipConsts.TabsMaxLength, 0);
            Check.Length(video, nameof(video), CharterShipConsts.VideoMaxLength, 0);
            OperatorName = operatorName;
            Season = season;
            Ship = ship;
            Itinerary = itinerary;
            Tabs = tabs;
            Featured = featured;
            FreeInternetOnBoard = freeInternetOnBoard;
            Internet = internet;
            TransferIncluded = transferIncluded;
            EnabledByUser = enabledByUser;
            B2B = b2B;
            B2C = b2C;
            B2B_Agent = b2B_Agent;
            B2C_Agent = b2C_Agent;
            ShipNamePrefix = shipNamePrefix;
            Video = video;
            DisabledBySystem = disabledBySystem;
            ShipAmenities = shipAmenities;
            ShipArticles = shipArticles;
            ShipPhotos = shipPhotos;
            CabinAmenities = cabinAmenities;
            CabinArticles = cabinArticles;
            CabinPhotos = cabinPhotos;
        }
    }
}