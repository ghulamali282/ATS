using System;
using System.ComponentModel.DataAnnotations;

namespace Ccm.MasterDatas
{
    public class MasterDataCreateDto
    {
        public Guid? ParentId { get; set; }
        [Required]
        [StringLength(MasterDataConsts.NameMaxLength)]
        public string Name { get; set; }
        public string Value { get; set; }
        public bool? InlineValue { get; set; }
        public bool VisibleToTenant { get; set; }
        public bool IsSection { get; set; }
        public bool IsRadio { get; set; }
        public bool IsExportable { get; set; }
        [StringLength(MasterDataConsts.IconMaxLength)]
        public string Icon { get; set; }
        [Required]
        [StringLength(MasterDataConsts.CultureNameMaxLength)]
        public string CultureName { get; set; }
        [Required]
        public int SortOrder { get; set; }
    }
}