using Ccm.MasterDatas;
using Ccm.Partners;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Ccm.AgePolicies
{
    public class AgePolicy : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string DemoField { get; set; }
        public Guid Name { get; set; }
        public Guid OperatorName { get; set; }

        public AgePolicy()
        {

        }

        public AgePolicy(Guid id, string demoField, Guid name, Guid operatorName)
        {
            Id = id;
            DemoField = demoField;
            Name = name;
            OperatorName = operatorName;
        }
    }
}