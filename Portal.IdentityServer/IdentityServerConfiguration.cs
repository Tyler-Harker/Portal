namespace Portal.IdentityServer
{
    public class IdentityServerConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public string AzureStorage { get; set; }
    }
}
