using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.CruiseRegions
{
    public class CruiseRegionUpdateDto
    {
        public string FreeEntry { get; set; }
        public Guid CruiseRegionName { get; set; }
    }
}