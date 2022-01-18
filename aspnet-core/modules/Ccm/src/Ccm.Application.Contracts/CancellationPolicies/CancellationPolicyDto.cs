using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.CancellationPolicies
{
    public class CancellationPolicyDto : EntityDto<Guid>
    {
        public string NameString { get; set; }
        public Guid OperatorName { get; set; }
        public Guid PolicyName { get; set; }
    }
}