using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.Countries
{
    public class Country : Entity<string>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string CountryName { get; set; }

        [NotNull]
        public virtual string CultureName { get; set; }

        public Country()
        {

        }

        public Country(string id, string countryName, string cultureName)
        {
            Id = id;
            Check.NotNull(countryName, nameof(countryName));
            Check.Length(countryName, nameof(countryName), CountryConsts.CountryNameMaxLength, 0);
            Check.NotNull(cultureName, nameof(cultureName));
            Check.Length(cultureName, nameof(cultureName), CountryConsts.CultureNameMaxLength, 0);
            CountryName = countryName;
            CultureName = cultureName;
        }
    }
}