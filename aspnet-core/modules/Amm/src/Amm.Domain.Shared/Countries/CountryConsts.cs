namespace Amm.Countries
{
    public static class CountryConsts
    {
        private const string DefaultSorting = "{0}CountryName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Country." : string.Empty);
        }

        public const int CultureNameMaxLength = 10;
        public const int CurrencyMaxLength = 50;
        public const int CurrencyCodeMaxLength = 3;
        public const int CurrencySymbolMaxLength = 10;
        public const int LanguageNameMaxLength = 50;
        public const int PlaceIdMaxLength = 50;
    }
}