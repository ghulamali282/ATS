using System;
using Volo.Abp.Application.Dtos;

namespace Amm.ShpCabins
{
    public class ShpCabinDto : EntityDto<Guid>
    {
        public Guid Ship { get; set; }
        public Guid CabinCategory { get; set; }
        public string CabinNo { get; set; }
        public int CabinNoNumeric { get; set; }
        public Guid BedLayout { get; set; }
        public int StandardCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public bool Portohole { get; set; }
        public bool Window { get; set; }
        public decimal CabinArea { get; set; }
        public bool Balcon { get; set; }
        public decimal BalconArea { get; set; }
        public bool IsDisabled { get; set; }
    }
}