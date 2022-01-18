using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.DepartureSeasons
{
    public class GetDepartureSeasonsInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public int? SeasonMin { get; set; }
        public int? SeasonMax { get; set; }
        public string SeasonName { get; set; }
        public Guid? Partner { get; set; }

        public GetDepartureSeasonsInput()
        {

        }
    }
}