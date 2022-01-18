using System;
using System.ComponentModel.DataAnnotations;

namespace Amm.AppDefaults
{
    public class AppDefaultCreateDto
    {
        [Required]
        [StringLength(AppDefaultConsts.SettingsNameMaxLength)]
        public string SettingsName { get; set; }
        [Required]
        [StringLength(AppDefaultConsts.SettingsValueMaxLength)]
        public string SettingsValue { get; set; }
    }
}