using System;
using Volo.Abp.Application.Dtos;

namespace Amm.Ships
{
    public class ShipDto : EntityDto<Guid>
    {
        public string ShipName { get; set; }
        public int YearBuild { get; set; }
        public int? YearRefurbished { get; set; }
        public bool EnsuitedCabins { get; set; }
        public int? SharedToilets { get; set; }
        public int? SharedShowers { get; set; }
        public int CrewNo { get; set; }
        public int Lenght { get; set; }
        public int Beam { get; set; }
        public int Draft { get; set; }
        public int CruiseSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string VideoUrl { get; set; }
        public bool UseCabinDeckPosition { get; set; }
        public bool UseDeckLocation { get; set; }
        public bool ShipEnabled { get; set; }
        public Guid HomePort { get; set; }
        public string Flag { get; set; }
        public Guid ShipCategory { get; set; }
        public Guid? ShipOperator { get; set; }
    }
}