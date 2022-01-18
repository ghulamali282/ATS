namespace Ccm.CharterShips
{
    public static class CharterShipConsts
    {
        private const string DefaultSorting = "{0}OperatorName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CharterShip." : string.Empty);
        }

        public const int TabsMaxLength = 500;
        public const int VideoMaxLength = 500;
    }
}