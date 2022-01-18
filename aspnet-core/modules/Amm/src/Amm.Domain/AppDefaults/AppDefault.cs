using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Amm.AppDefaults
{
    public class AppDefault : Entity<Guid>
    {
        [NotNull]
        public virtual string SettingsName { get; set; }

        [NotNull]
        public virtual string SettingsValue { get; set; }

        public AppDefault()
        {

        }

        public AppDefault(Guid id, string settingsName, string settingsValue)
        {
            Id = id;
            Check.NotNull(settingsName, nameof(settingsName));
            Check.Length(settingsName, nameof(settingsName), AppDefaultConsts.SettingsNameMaxLength, 0);
            Check.NotNull(settingsValue, nameof(settingsValue));
            Check.Length(settingsValue, nameof(settingsValue), AppDefaultConsts.SettingsValueMaxLength, 0);
            SettingsName = settingsName;
            SettingsValue = settingsValue;
        }
    }
}