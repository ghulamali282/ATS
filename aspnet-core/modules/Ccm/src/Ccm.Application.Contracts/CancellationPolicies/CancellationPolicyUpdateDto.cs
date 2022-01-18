using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.CancellationPolicies
{
    public class CancellationPolicyUpdateDto
    {
        [Required]
        public string NameString { get; set; }
        public Guid OperatorName { get; set; }
        public Guid PolicyName { get; set; }
    }
}