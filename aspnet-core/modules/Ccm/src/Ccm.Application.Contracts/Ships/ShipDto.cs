using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Ships
{
    public class ShipDto : EntityDto<Guid>
    {
        public string ShipName { get; set; }
        public Guid ShipCategory { get; set; }
        public Guid? ShipOperator { get; set; }
        public Guid? Type { get; set; }
        public string Flag { get; set; }
        public Guid HomePort { get; set; }
        public Guid? Manufacturer { get; set; }
        public Guid? Model { get; set; }
        public int YearBuild { get; set; }
    }
}