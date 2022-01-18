using System;
using Volo.Abp.Application.Dtos;

namespace Ccm.MasterDatas
{
    public class MasterDataDto : EntityDto<Guid>
    {
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool? InlineValue { get; set; }
        public bool VisibleToTenant { get; set; }
        public bool IsSection { get; set; }
        public bool IsRadio { get; set; }
        public bool IsExportable { get; set; }
        public string Icon { get; set; }
        public string CultureName { get; set; }
        public int SortOrder { get; set; }
    }
}