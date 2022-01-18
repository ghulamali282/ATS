using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.Ships
{
    public class ShipCreateDto
    {
        [Required]
        [StringLength(ShipConsts.ShipNameMaxLength)]
        public string ShipName { get; set; }
        [Required]
        public Guid ShipCategory { get; set; }
        public Guid? ShipOperator { get; set; }
        public Guid? Type { get; set; }
        [Required]
        [StringLength(ShipConsts.FlagMaxLength)]
        public string Flag { get; set; }
        [Required]
        public Guid HomePort { get; set; }
        public Guid? Manufacturer { get; set; }
        public Guid? Model { get; set; }
        [Required]
        public int YearBuild { get; set; }
    }
}