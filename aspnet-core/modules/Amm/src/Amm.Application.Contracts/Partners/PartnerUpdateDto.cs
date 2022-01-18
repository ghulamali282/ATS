using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.Partners
{
    public class PartnerUpdateDto
    {
        [Required]
        [StringLength(PartnerConsts.PartnerNameMaxLength)]
        public string PartnerName { get; set; }
    }
}