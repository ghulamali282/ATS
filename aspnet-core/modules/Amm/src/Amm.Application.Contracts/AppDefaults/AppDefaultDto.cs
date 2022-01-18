using System;
using Volo.Abp.Application.Dtos;

namespace Amm.AppDefaults
{
    public class AppDefaultDto : EntityDto<Guid>
    {
        public string SettingsName { get; set; }
        public string SettingsValue { get; set; }
    }
}