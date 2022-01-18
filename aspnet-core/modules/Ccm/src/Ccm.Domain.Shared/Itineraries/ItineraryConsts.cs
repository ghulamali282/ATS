namespace Ccm.Itineraries
{
    public static class ItineraryConsts
    {
        private const string DefaultSorting = "{0}ItineraryNameString asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Itinerary." : string.Empty);
        }

        public const int ItineraryCodeMaxLength = 10;
        public const int GoogleMapLinkMaxLength = 100;
        public const int EmbarcationLatitudeMaxLength = 50;
        public const int EmbarcationLongitudeMaxLength = 50;
        public const int DisembarkationLatitudeMaxLength = 50;
        public const int DisembarkationLongitudeMaxLength = 50;
        public const int CheckInTimeMaxLength = 3;
        public const int CheckOutTimeMaxLength = 3;
        public const int VideoMaxLength = 1000;
    }
}