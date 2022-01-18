namespace Amm.ShipDecks
{
    public static class ShipDeckConsts
    {
        private const string DefaultSorting = "{0}SortOrder asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShipDeck." : string.Empty);
        }

    }
}