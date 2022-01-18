using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.ShpCabins
{
    public class ShpCabinCreateDto
    {
        [Required]
        public Guid Ship { get; set; }
        [Required]
        public Guid CabinCategory { get; set; }
        [Required]
        [StringLength(ShpCabinConsts.CabinNoMaxLength)]
        public string CabinNo { get; set; }
        [Required]
        public int CabinNoNumeric { get; set; }
        [Required]
        public Guid BedLayout { get; set; }
        [Required]
        public int StandardCapacity { get; set; }
        [Required]
        public int MaxCapacity { get; set; }
        [Required]
        public bool Portohole { get; set; }
        [Required]
        public bool Window { get; set; }
        [Required]
        public decimal CabinArea { get; set; }
        [Required]
        public bool Balcon { get; set; }
        [Required]
        public decimal BalconArea { get; set; }
        [Required]
        public bool IsDisabled { get; set; }
    }
}