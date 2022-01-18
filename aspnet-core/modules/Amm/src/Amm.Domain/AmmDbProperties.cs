namespace Amm
{
    public static class AmmDbProperties
    {
        public static string DbTablePrefix { get; set; } = "Amm";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "AmmConn";
    }
}
