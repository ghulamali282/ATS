using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Departures
{
    public class DepartureDto : EntityDto<Guid>
    {
        public string DeparturesArray { get; set; }
        public string SeasonGroup { get; set; }
        public Guid Partner { get; set; }
        public Guid SeasonName { get; set; }
    }
}