using Amm.Destinations;
using Amm.Countries;
using Amm.MasterDatas;
using Amm.ShipOperators;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.Ships
{
    public class Ship : Entity<Guid>
    {
        [NotNull]
        public virtual string ShipName { get; set; }

        public virtual int YearBuild { get; set; }

        public virtual int? YearRefurbished { get; set; }

        public virtual bool EnsuitedCabins { get; set; }

        public virtual int? SharedToilets { get; set; }

        public virtual int? SharedShowers { get; set; }

        public virtual int CrewNo { get; set; }

        public virtual int Lenght { get; set; }

        public virtual int Beam { get; set; }

        public virtual int Draft { get; set; }

        public virtual int CruiseSpeed { get; set; }

        public virtual int MaxSpeed { get; set; }

        [CanBeNull]
        public virtual string VideoUrl { get; set; }

        public virtual bool UseCabinDeckPosition { get; set; }

        public virtual bool UseDeckLocation { get; set; }

        public virtual bool ShipEnabled { get; set; }
        public Guid HomePort { get; set; }
        public string Flag { get; set; }
        public Guid ShipCategory { get; set; }
        public Guid? ShipOperator { get; set; }

        public Ship()
        {

        }

        public Ship(Guid id, string shipName, Guid homePort, string flag, Guid shipCategory, int yearBuild, bool ensuitedCabins, int crewNo, int lenght, int beam, int draft, int cruiseSpeed, int maxSpeed, bool useCabinDeckPosition, bool useDeckLocation, bool shipEnabled, int? yearRefurbished = null, int? sharedToilets = null, int? sharedShowers = null, string videoUrl = null)
        {
            Id = id;
            Check.NotNull(shipName, nameof(shipName));
            Check.Length(shipName, nameof(shipName), ShipConsts.ShipNameMaxLength, 0);
            Check.Length(videoUrl, nameof(videoUrl), ShipConsts.VideoUrlMaxLength, 0);
            ShipName = shipName;
            YearBuild = yearBuild;
            EnsuitedCabins = ensuitedCabins;
            CrewNo = crewNo;
            Lenght = lenght;
            Beam = beam;
            Draft = draft;
            CruiseSpeed = cruiseSpeed;
            MaxSpeed = maxSpeed;
            UseCabinDeckPosition = useCabinDeckPosition;
            UseDeckLocation = useDeckLocation;
            ShipEnabled = shipEnabled;
            YearRefurbished = yearRefurbished;
            SharedToilets = sharedToilets;
            SharedShowers = sharedShowers;
            VideoUrl = videoUrl;
            HomePort = homePort;
            Flag = flag;
            ShipCategory = shipCategory;
        }
    }
}