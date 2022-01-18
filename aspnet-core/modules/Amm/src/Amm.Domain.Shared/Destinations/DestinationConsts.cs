namespace Amm.Destinations
{
    public static class DestinationConsts
    {
        private const string DefaultSorting = "{0}City asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Destination." : string.Empty);
        }

        public const int CityMaxLength = 128;
        public const int CityLocalNameMaxLength = 128;
        public const int VideoUrlMaxLength = 500;
        public const int PlaceIdMaxLength = 50;
    }
}