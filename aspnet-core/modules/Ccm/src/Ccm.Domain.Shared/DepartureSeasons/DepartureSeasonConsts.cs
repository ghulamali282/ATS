namespace Ccm.DepartureSeasons
{
    public static class DepartureSeasonConsts
    {
        private const string DefaultSorting = "{0}Season asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "DepartureSeason." : string.Empty);
        }

    }
}