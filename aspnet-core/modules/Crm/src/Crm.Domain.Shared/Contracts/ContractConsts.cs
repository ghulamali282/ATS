namespace Crm.Contracts
{
    public static class ContractConsts
    {
        private const string DefaultSorting = "{0}OperatorName asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Contract." : string.Empty);
        }

    }
}