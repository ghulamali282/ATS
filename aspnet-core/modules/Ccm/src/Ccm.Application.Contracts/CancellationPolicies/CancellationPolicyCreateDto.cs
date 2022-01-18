using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.CancellationPolicies
{
    public class CancellationPolicyCreateDto
    {
        [Required]
        public string NameString { get; set; }
        public Guid OperatorName { get; set; }
        public Guid PolicyName { get; set; }
    }
}