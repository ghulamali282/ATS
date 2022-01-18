using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ATS
{
    [Dependency(ReplaceServices = true)]
    public class ATSBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ATS";
    }
}
