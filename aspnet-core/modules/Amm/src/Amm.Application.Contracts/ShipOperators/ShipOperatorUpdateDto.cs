using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.ShipOperators
{
    public class ShipOperatorUpdateDto
    {
        [Required]
        [StringLength(ShipOperatorConsts.OperatorNameMaxLength)]
        public string OperatorName { get; set; }
    }
}