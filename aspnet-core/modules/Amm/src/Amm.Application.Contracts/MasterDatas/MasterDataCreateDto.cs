using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.MasterDatas
{
    public class MasterDataCreateDto
    {
        public Guid? ParentId { get; set; }
        [Required]
        [StringLength(MasterDataConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public int SortOrder { get; set; }
    }
}