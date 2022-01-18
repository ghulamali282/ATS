namespace Ccm.MasterDatas
{
    public static class MasterDataConsts
    {
        private const string DefaultSorting = "{0}SortOrder asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "MasterData." : string.Empty);
        }

        public const int NameMaxLength = 100;
        public const int IconMaxLength = 50;
        public const int CultureNameMaxLength = 10;
    }
}