using Ccm.Partners;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.DepartureSeasons
{
    public class DepartureSeason : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual int Season { get; set; }

        [NotNull]
        public virtual string SeasonName { get; set; }
        public Guid Partner { get; set; }

        public DepartureSeason()
        {

        }

        public DepartureSeason(Guid id, int season, string seasonName, Guid partner)
        {
            Id = id;
            Check.NotNull(seasonName, nameof(seasonName));
            Season = season;
            SeasonName = seasonName;
            Partner = partner;
        }
    }
}