namespace Amm.Marinas
{
    public static class MarinaConsts
    {
        private const string DefaultSorting = "{0}MarinaNameString asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Marina." : string.Empty);
        }

        public const int MarinaNameStringMaxLength = 50;
        public const int LatitudeMaxLength = 50;
        public const int LongitudeMaxLength = 50;
    }
}