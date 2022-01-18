using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.AgePolicies
{
    public class AgePolicyUpdateDto
    {
        public string DemoField { get; set; }
        public Guid Name { get; set; }
        public Guid OperatorName { get; set; }
    }
}