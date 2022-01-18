using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.DepartureSeasons
{
    public class DepartureSeasonDto : EntityDto<Guid>
    {
        public int Season { get; set; }
        public string SeasonName { get; set; }
        public Guid Partner { get; set; }
    }
}