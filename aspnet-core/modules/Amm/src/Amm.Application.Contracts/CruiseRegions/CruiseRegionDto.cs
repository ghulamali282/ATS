using System;
using Volo.Abp.Application.Dtos;

namespace Amm.CruiseRegions
{
    public class CruiseRegionDto : EntityDto<Guid>
    {
        public string FreeEntry { get; set; }
        public Guid CruiseRegionName { get; set; }
    }
}