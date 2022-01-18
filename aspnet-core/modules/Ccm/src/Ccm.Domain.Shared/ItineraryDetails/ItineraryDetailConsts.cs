namespace Ccm.ItineraryDetails
{
    public static class ItineraryDetailConsts
    {
        private const string DefaultSorting = "{0}Itinerary asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ItineraryDetail." : string.Empty);
        }

        public const int PortsMaxLength = 1000;
        public const int AlternativePortsMaxLength = 1000;
    }
}