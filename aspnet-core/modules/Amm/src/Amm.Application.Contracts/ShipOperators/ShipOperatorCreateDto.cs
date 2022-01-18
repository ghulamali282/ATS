using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.ShipOperators
{
    public class ShipOperatorCreateDto
    {
        [Required]
        [StringLength(ShipOperatorConsts.OperatorNameMaxLength)]
        public string OperatorName { get; set; }
    }
}