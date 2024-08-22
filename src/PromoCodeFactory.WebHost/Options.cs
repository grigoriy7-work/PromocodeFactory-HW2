namespace PromoCodeFactory.WebHost
{
    public class Options
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string SqliteConnectionString { get; set; } = string.Empty;
        public string PostgresConnectionString { get; set; } = string.Empty;
    }
}