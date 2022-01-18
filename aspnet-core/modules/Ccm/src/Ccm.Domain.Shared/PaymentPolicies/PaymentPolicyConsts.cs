namespace Ccm.PaymentPolicies
{
    public static class PaymentPolicyConsts
    {
        private const string DefaultSorting = "{0}DelayedDepositAt asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "PaymentPolicy." : string.Empty);
        }

        public const int DelayedDepositAtMaxLength = 50;
        public const int DepositTypeMaxLength = 3;
    }
}