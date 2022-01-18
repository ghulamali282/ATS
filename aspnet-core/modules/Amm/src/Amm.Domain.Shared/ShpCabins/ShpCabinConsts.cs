namespace Amm.ShpCabins
{
    public static class ShpCabinConsts
    {
        private const string DefaultSorting = "{0}Ship asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShpCabin." : string.Empty);
        }

        public const int CabinNoMaxLength = 10;
    }
}