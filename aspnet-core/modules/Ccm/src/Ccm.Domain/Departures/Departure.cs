using Ccm.Partners;
using Ccm.DepartureSeasons;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.Departures
{
    public class Departure : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string DeparturesArray { get; set; }

        [NotNull]
        public virtual string SeasonGroup { get; set; }
        public Guid Partner { get; set; }
        public Guid SeasonName { get; set; }

        public Departure()
        {

        }

        public Departure(Guid id, string departuresArray, string seasonGroup, Guid partner, Guid seasonName)
        {
            Id = id;
            Check.NotNull(departuresArray, nameof(departuresArray));
            Check.NotNull(seasonGroup, nameof(seasonGroup));
            Check.Length(seasonGroup, nameof(seasonGroup), DepartureConsts.SeasonGroupMaxLength, 0);
            DeparturesArray = departuresArray;
            SeasonGroup = seasonGroup;
            Partner = partner;
            SeasonName = seasonName;
        }
    }
}