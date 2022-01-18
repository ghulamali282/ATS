namespace Ccm.Cruises
{
    public static class CruiseConsts
    {
        private const string DefaultSorting = "{0}Season asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Cruise." : string.Empty);
        }

        public const int VideoMaxLength = 500;
    }
}