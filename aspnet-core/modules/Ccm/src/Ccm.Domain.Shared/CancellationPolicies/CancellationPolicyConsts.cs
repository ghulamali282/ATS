namespace Ccm.CancellationPolicies
{
    public static class CancellationPolicyConsts
    {
        private const string DefaultSorting = "{0}NameString asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CancellationPolicy." : string.Empty);
        }

    }
}