using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.Destinations
{
    public class Destination : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string City { get; set; }

        public Destination()
        {

        }

        public Destination(Guid id, string city)
        {
            Id = id;
            Check.NotNull(city, nameof(city));
            Check.Length(city, nameof(city), DestinationConsts.CityMaxLength, 0);
            City = city;
        }
    }
}