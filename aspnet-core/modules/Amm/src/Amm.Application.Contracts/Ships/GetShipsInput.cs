using Volo.Abp.Application.Dtos;
using System;

namespace Amm.Ships
{
    public class GetShipsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string ShipName { get; set; }
        public int? YearBuildMin { get; set; }
        public int? YearBuildMax { get; set; }
        public int? YearRefurbishedMin { get; set; }
        public int? YearRefurbishedMax { get; set; }
        public bool? EnsuitedCabins { get; set; }
        public int? SharedToiletsMin { get; set; }
        public int? SharedToiletsMax { get; set; }
        public int? SharedShowersMin { get; set; }
        public int? SharedShowersMax { get; set; }
        public int? CrewNoMin { get; set; }
        public int? CrewNoMax { get; set; }
        public int? LenghtMin { get; set; }
        public int? LenghtMax { get; set; }
        public int? BeamMin { get; set; }
        public int? BeamMax { get; set; }
        public int? DraftMin { get; set; }
        public int? DraftMax { get; set; }
        public int? CruiseSpeedMin { get; set; }
        public int? CruiseSpeedMax { get; set; }
        public int? MaxSpeedMin { get; set; }
        public int? MaxSpeedMax { get; set; }
        public string VideoUrl { get; set; }
        public bool? UseCabinDeckPosition { get; set; }
        public bool? UseDeckLocation { get; set; }
        public bool? ShipEnabled { get; set; }
        public Guid? HomePort { get; set; }
        public string Flag { get; set; }
        public Guid? ShipCategory { get; set; }
        public Guid? ShipOperator { get; set; }

        public GetShipsInput()
        {

        }
    }
}