using Amm.MasterDatas;
using Amm.Destinations;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.Marinas
{
    public class Marina : Entity<Guid>
    {
        [CanBeNull]
        public virtual string MarinaNameString { get; set; }

        [NotNull]
        public virtual string Latitude { get; set; }

        [NotNull]
        public virtual string Longitude { get; set; }
        public Guid MarinaName { get; set; }
        public Guid Destination { get; set; }

        public Marina()
        {

        }

        public Marina(Guid id, Guid marinaName, Guid destination, string latitude, string longitude, string marinaNameString = null)
        {
            Id = id;
            Check.NotNull(latitude, nameof(latitude));
            Check.Length(latitude, nameof(latitude), MarinaConsts.LatitudeMaxLength, 0);
            Check.NotNull(longitude, nameof(longitude));
            Check.Length(longitude, nameof(longitude), MarinaConsts.LongitudeMaxLength, 0);
            Check.Length(marinaNameString, nameof(marinaNameString), MarinaConsts.MarinaNameStringMaxLength, 0);
            Latitude = latitude;
            Longitude = longitude;
            MarinaNameString = marinaNameString;
            MarinaName = marinaName;
            Destination = destination;
        }
    }
}