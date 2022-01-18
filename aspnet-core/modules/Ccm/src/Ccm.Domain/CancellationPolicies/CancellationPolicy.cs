using Ccm.Partners;
using Ccm.MasterDatas;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.CancellationPolicies
{
    public class CancellationPolicy : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string NameString { get; set; }
        public Guid OperatorName { get; set; }
        public Guid PolicyName { get; set; }

        public CancellationPolicy()
        {

        }

        public CancellationPolicy(Guid id, string nameString, Guid operatorName, Guid policyName)
        {
            Id = id;
            Check.NotNull(nameString, nameof(nameString));
            NameString = nameString;
            OperatorName = operatorName;
            PolicyName = policyName;
        }
    }
}