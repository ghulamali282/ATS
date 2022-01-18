namespace Amm.CruiseRegions
{
    public static class CruiseRegionConsts
    {
        private const string DefaultSorting = "{0}FreeEntry asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CruiseRegion." : string.Empty);
        }

    }
}