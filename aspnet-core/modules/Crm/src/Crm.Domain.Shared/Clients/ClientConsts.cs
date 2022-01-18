namespace Crm.Clients
{
    public static class ClientConsts
    {
        private const string DefaultSorting = "{0}Title asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Client." : string.Empty);
        }

        public const int FirstNameMaxLength = 50;
        public const int SecondNameMaxLength = 50;
        public const int EmailMaxLength = 50;
        public const int CountryMaxLength = 2;
        public const int NacionalityMaxLength = 2;
        public const int StateMaxLength = 50;
        public const int ZipCodeMaxLength = 50;
        public const int CityMaxLength = 50;
        public const int CellPhoneMaxLength = 50;
        public const int DocumentNoMaxLength = 50;
    }
}