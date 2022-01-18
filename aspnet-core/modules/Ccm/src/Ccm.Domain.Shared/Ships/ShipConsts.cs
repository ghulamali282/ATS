namespace Ccm.Ships
{
    public static class ShipConsts
    {
        private const string DefaultSorting = "{0}ShipName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Ship." : string.Empty);
        }

        public const int ShipNameMaxLength = 50;
        public const int FlagMaxLength = 2;
    }
}