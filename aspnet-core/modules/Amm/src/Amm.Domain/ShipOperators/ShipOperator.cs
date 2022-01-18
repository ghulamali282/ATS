using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.ShipOperators
{
    public class ShipOperator : Entity<Guid>
    {
        [NotNull]
        public virtual string OperatorName { get; set; }

        public ShipOperator()
        {

        }

        public ShipOperator(Guid id, string operatorName)
        {
            Id = id;
            Check.NotNull(operatorName, nameof(operatorName));
            Check.Length(operatorName, nameof(operatorName), ShipOperatorConsts.OperatorNameMaxLength, 0);
            OperatorName = operatorName;
        }
    }
}