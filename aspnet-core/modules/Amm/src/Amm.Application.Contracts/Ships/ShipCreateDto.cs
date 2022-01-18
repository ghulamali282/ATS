using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.Ships
{
    public class ShipCreateDto
    {
        [Required]
        [StringLength(ShipConsts.ShipNameMaxLength)]
        public string ShipName { get; set; }
        [Required]
        public int YearBuild { get; set; }
        public int? YearRefurbished { get; set; }
        [Required]
        public bool EnsuitedCabins { get; set; }
        public int? SharedToilets { get; set; }
        public int? SharedShowers { get; set; }
        [Required]
        public int CrewNo { get; set; }
        [Required]
        public int Lenght { get; set; }
        [Required]
        public int Beam { get; set; }
        [Required]
        public int Draft { get; set; }
        [Required]
        public int CruiseSpeed { get; set; }
        [Required]
        public int MaxSpeed { get; set; }
        [StringLength(ShipConsts.VideoUrlMaxLength)]
        public string VideoUrl { get; set; }
        [Required]
        public bool UseCabinDeckPosition { get; set; }
        [Required]
        public bool UseDeckLocation { get; set; }
        public bool ShipEnabled { get; set; }
        public Guid HomePort { get; set; }
        public string Flag { get; set; }
        public Guid ShipCategory { get; set; }
        public Guid? ShipOperator { get; set; }
    }
}