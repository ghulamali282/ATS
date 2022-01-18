using System;
using Volo.Abp.Application.Dtos;

namespace Amm.Partners
{
    public class PartnerDto : EntityDto<Guid>
    {
        public string PartnerName { get; set; }
    }
}