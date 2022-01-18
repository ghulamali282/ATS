using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.AgePolicyDetails
{
    public class AgePolicyDetailCreateDto
    {
        [Required]
        public int AgeFrom { get; set; }
        [Required]
        public Guid AgePolicy { get; set; }
        [Required]
        public int AgeTo { get; set; }
        public Guid Service { get; set; }
    }
}