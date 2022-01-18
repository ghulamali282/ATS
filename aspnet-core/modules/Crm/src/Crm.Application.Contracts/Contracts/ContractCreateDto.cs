using System;
using System.ComponentModel.DataAnnotations;

namespace Crm.Contracts
{
    public class ContractCreateDto
    {
        [Required]
        public Guid OperatorName { get; set; }
        [Required]
        public int Season { get; set; }
        [Required]
        public bool IsEnabledAgent { get; set; }
        [Required]
        public bool IsEnabledOperator { get; set; }
    }
}