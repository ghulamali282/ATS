namespace Amm.ShipOperators
{
    public static class ShipOperatorConsts
    {
        private const string DefaultSorting = "{0}OperatorName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShipOperator." : string.Empty);
        }

        public const int OperatorNameMaxLength = 64;
    }
}