namespace Portal.WebApi
{
    public class WebApiConfiguration
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public string AzureStorage { get; set; }
    }
}
