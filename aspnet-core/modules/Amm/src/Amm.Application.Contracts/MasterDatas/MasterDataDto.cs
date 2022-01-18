using System;
using Volo.Abp.Application.Dtos;

namespace Amm.MasterDatas
{
    public class MasterDataDto : EntityDto<Guid>
    {
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
    }
}