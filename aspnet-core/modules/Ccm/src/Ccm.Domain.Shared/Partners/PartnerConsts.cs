namespace Ccm.Partners
{
    public static class PartnerConsts
    {
        private const string DefaultSorting = "{0}PartnerName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Partner." : string.Empty);
        }

        public const int PartnerNameMaxLength = 100;
        public const int TaxNoMaxLength = 50;
        public const int BookingEmailMaxLength = 256;
        public const int BookingCellPhoneMaxLength = 16;
        public const int EmailMaxLength = 256;
        public const int PhoneMaxLength = 16;
    }
}