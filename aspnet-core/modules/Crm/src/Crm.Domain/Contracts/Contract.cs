using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Crm.Contracts
{
    public class Contract : Entity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid OperatorName { get; set; }

        public virtual int Season { get; set; }

        public virtual bool IsEnabledAgent { get; set; }

        public virtual bool IsEnabledOperator { get; set; }

        public Contract()
        {

        }

        public Contract(Guid id, Guid operatorName, int season, bool isEnabledAgent, bool isEnabledOperator)
        {
            Id = id;
            OperatorName = operatorName;
            Season = season;
            IsEnabledAgent = isEnabledAgent;
            IsEnabledOperator = isEnabledOperator;
        }
    }
}