namespace Amm.ShipCabinTypes
{
    public static class ShipCabinTypeConsts
    {
        private const string DefaultSorting = "{0}SortOrder asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShipCabinType." : string.Empty);
        }

    }
}