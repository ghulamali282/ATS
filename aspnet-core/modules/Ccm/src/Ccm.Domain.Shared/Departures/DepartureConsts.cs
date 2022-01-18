namespace Ccm.Departures
{
    public static class DepartureConsts
    {
        private const string DefaultSorting = "{0}DeparturesArray asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Departure." : string.Empty);
        }

        public const int SeasonGroupMaxLength = 1;
    }
}