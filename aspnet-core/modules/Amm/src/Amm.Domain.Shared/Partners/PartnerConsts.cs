namespace Amm.Partners
{
    public static class PartnerConsts
    {
        private const string DefaultSorting = "{0}PartnerName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Partner." : string.Empty);
        }

        public const int PartnerNameMaxLength = 100;
    }
}