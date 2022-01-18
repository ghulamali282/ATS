using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.AgePolicyDetails
{
    public class AgePolicyDetailDto : EntityDto<Guid>
    {
        public int AgeFrom { get; set; }
        public Guid AgePolicy { get; set; }
        public int AgeTo { get; set; }
        public Guid Service { get; set; }
    }
}