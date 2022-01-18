using Volo.Abp.Application.Dtos;
using System;

namespace Ccm.Departures
{
    public class GetDeparturesInput : PagedAndSortedResultRequestDto
    {
        public string FilterText { get; set; }

        public string DeparturesArray { get; set; }
        public string SeasonGroup { get; set; }
        public Guid? Partner { get; set; }
        public Guid? SeasonName { get; set; }

        public GetDeparturesInput()
        {

        }
    }
}