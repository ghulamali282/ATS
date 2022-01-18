using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.Ships
{
    public class GetShipsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string ShipName { get; set; }
        public Guid? ShipCategory { get; set; }
        public Guid? ShipOperator { get; set; }
        public Guid? Type { get; set; }
        public string Flag { get; set; }
        public Guid? HomePort { get; set; }
        public Guid? Manufacturer { get; set; }
        public Guid? Model { get; set; }
        public int? YearBuildMin { get; set; }
        public int? YearBuildMax { get; set; }

        public GetShipsInput()
        {

        }
    }
}