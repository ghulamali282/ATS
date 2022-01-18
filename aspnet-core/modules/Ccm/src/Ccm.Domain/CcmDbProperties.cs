namespace Ccm
{
    public static class CcmDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Ccm";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "CcmConn";
    }
}
