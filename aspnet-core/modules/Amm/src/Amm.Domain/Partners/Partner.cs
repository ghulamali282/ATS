using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.Partners
{
    public class Partner : Entity<Guid>
    {
        [NotNull]
        public virtual string PartnerName { get; set; }

        public Partner()
        {

        }

        public Partner(Guid id, string partnerName)
        {
            Id = id;
            Check.NotNull(partnerName, nameof(partnerName));
            Check.Length(partnerName, nameof(partnerName), PartnerConsts.PartnerNameMaxLength, 0);
            PartnerName = partnerName;
        }
    }
}