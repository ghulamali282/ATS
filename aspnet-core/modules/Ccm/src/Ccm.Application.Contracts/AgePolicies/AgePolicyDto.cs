using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.AgePolicies
{
    public class AgePolicyDto : EntityDto<Guid>
    {
        public string DemoField { get; set; }
        public Guid Name { get; set; }
        public Guid OperatorName { get; set; }
    }
}