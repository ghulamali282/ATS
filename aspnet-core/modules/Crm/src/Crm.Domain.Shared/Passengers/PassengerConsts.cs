namespace Crm.Passengers
{
    public static class PassengerConsts
    {
        private const string DefaultSorting = "{0}Reservation asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Passenger." : string.Empty);
        }

        public const int FirstNameMaxLength = 50;
        public const int LastNameMaxLength = 50;
        public const int CountryMaxLength = 2;
        public const int DocumentNoMaxLength = 50;
    }
}