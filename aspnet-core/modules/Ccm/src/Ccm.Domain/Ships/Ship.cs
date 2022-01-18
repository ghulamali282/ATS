using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.Ships
{
    public class Ship : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string ShipName { get; set; }

        public virtual Guid ShipCategory { get; set; }

        public virtual Guid? ShipOperator { get; set; }

        public virtual Guid? Type { get; set; }

        [NotNull]
        public virtual string Flag { get; set; }

        public virtual Guid HomePort { get; set; }

        public virtual Guid? Manufacturer { get; set; }

        public virtual Guid? Model { get; set; }

        public virtual int YearBuild { get; set; }

        public Ship()
        {

        }

        public Ship(Guid id, string shipName, Guid shipCategory, string flag, Guid homePort, int yearBuild, Guid? shipOperator = null, Guid? type = null, Guid? manufacturer = null, Guid? model = null)
        {
            Id = id;
            Check.NotNull(shipName, nameof(shipName));
            Check.Length(shipName, nameof(shipName), ShipConsts.ShipNameMaxLength, 0);
            Check.NotNull(flag, nameof(flag));
            Check.Length(flag, nameof(flag), ShipConsts.FlagMaxLength, 0);
            ShipName = shipName;
            ShipCategory = shipCategory;
            Flag = flag;
            HomePort = homePort;
            YearBuild = yearBuild;
            ShipOperator = shipOperator;
            Type = type;
            Manufacturer = manufacturer;
            Model = model;
        }
    }
}