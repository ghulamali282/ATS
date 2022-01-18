namespace Amm.BookingStatuses
{
    public static class BookingStatusConsts
    {
        private const string DefaultSorting = "{0}StatusColor asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "BookingStatus." : string.Empty);
        }

    }
}