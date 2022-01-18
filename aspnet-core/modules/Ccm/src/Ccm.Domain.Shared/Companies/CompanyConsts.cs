namespace Ccm.Companies
{
    public static class CompanyConsts
    {
        private const string DefaultSorting = "{0}LegalName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Company." : string.Empty);
        }

        public const int LegalNameMaxLength = 50;
        public const int CompanyCodeMaxLength = 5;
        public const int StreetMaxLength = 50;
        public const int StreetNumberMaxLength = 50;
        public const int ZipCodeMaxLength = 50;
        public const int CityMaxLength = 50;
        public const int StateRegionMaxLength = 50;
        public const int CountryMaxLength = 2;
        public const int TaxNoMaxLength = 50;
        public const int TravelAgencyCodeMaxLength = 50;
        public const int InvoicePrefixMaxLength = 10;
        public const int WebSiteMaxLength = 50;
        public const int CompanyEmailMaxLength = 50;
        public const int TelephoneMaxLength = 50;
        public const int FaxMaxLength = 50;
        public const int FacebookPageMaxLength = 50;
        public const int TwiterPageMaxLength = 50;
        public const int InstagramMaxLength = 50;
        public const int CeoNameMaxLength = 50;
        public const int CeoEmailMaxLength = 50;
        public const int TenantCurrencyMaxLength = 3;
        public const int DefaultCruiseDepositTypeMaxLength = 3;
        public const int DefautCharterDepositTypeMaxLength = 3;
    }
}