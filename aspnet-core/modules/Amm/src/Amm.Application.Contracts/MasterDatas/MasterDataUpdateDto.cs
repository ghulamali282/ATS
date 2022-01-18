using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.MasterDatas
{
    public class MasterDataUpdateDto
    {
        public Guid? ParentId { get; set; }
        [Required]
        [StringLength(MasterDataConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public int SortOrder { get; set; }
    }
}