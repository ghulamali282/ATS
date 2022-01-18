using Volo.Abp.Features;
using ATS.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;

namespace ATS.Features
{
    public class ATSFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            var features = context.AddGroup(ATSFeatures.GroupName);
            features.AddFeature(
                ATSFeatures.Ccm,
                defaultValue: "false",
                displayName: L("Features:CcmModule"),
                valueType: new ToggleStringValueType(),
                isVisibleToClients: true
                );
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<ATSResource>(name);
        }
    }
}
