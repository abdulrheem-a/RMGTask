namespace RMGTask.Core.Configuration
{
    public class RMGTaskSettings
    {
        public string ConnectionString { get; set; }

        public Tokens Tokens { get; set; }
    }

    public class Tokens
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
    }
}
