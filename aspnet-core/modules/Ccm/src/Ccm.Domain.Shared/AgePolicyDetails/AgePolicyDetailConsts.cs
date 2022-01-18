namespace Ccm.AgePolicyDetails
{
    public static class AgePolicyDetailConsts
    {
        private const string DefaultSorting = "{0}AgeFrom asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "AgePolicyDetail." : string.Empty);
        }

    }
}