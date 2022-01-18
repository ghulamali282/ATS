using Volo.Abp.Application.Dtos;
using System;

namespace Amm.CruiseRegions
{
    public class GetCruiseRegionsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string FreeEntry { get; set; }
        public Guid? CruiseRegionName { get; set; }

        public GetCruiseRegionsInput()
        {

        }
    }
}