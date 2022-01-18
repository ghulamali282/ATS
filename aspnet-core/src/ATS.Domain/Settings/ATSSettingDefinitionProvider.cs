using Volo.Abp.Settings;

namespace ATS.Settings
{
    public class ATSSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(new SettingDefinition(ATSSettings.WorkingYear, "2022"));
        }
    }
}
