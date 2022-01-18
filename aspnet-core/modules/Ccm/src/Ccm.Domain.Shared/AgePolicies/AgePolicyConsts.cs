namespace Ccm.AgePolicies
{
    public static class AgePolicyConsts
    {
        private const string DefaultSorting = "{0}DemoField asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "AgePolicy." : string.Empty);
        }

    }
}