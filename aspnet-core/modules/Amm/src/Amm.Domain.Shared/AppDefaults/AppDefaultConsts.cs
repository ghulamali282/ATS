namespace Amm.AppDefaults
{
    public static class AppDefaultConsts
    {
        private const string DefaultSorting = "{0}SettingsName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "AppDefault." : string.Empty);
        }

        public const int SettingsNameMaxLength = 50;
        public const int SettingsValueMaxLength = 128;
    }
}