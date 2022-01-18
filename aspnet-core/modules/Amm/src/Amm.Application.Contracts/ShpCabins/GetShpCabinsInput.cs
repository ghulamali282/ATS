using Volo.Abp.Application.Dtos;
using System;

namespace Amm.ShpCabins
{
    public class GetShpCabinsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public Guid? Ship { get; set; }
        public Guid? CabinCategory { get; set; }
        public string CabinNo { get; set; }
        public int? CabinNoNumericMin { get; set; }
        public int? CabinNoNumericMax { get; set; }
        public Guid? BedLayout { get; set; }
        public int? StandardCapacityMin { get; set; }
        public int? StandardCapacityMax { get; set; }
        public int? MaxCapacityMin { get; set; }
        public int? MaxCapacityMax { get; set; }
        public bool? Portohole { get; set; }
        public bool? Window { get; set; }
        public decimal? CabinAreaMin { get; set; }
        public decimal? CabinAreaMax { get; set; }
        public bool? Balcon { get; set; }
        public decimal? BalconAreaMin { get; set; }
        public decimal? BalconAreaMax { get; set; }
        public bool? IsDisabled { get; set; }

        public GetShpCabinsInput()
        {

        }
    }
}