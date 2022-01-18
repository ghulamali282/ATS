using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.Destinations
{
    public class DestinationDto : EntityDto<Guid>
    {
        public string City { get; set; }
    }
}