namespace DSM.Core.Interfaces.AppServices
{
    public interface ISiteBinding
    {
        string Host { get; set; }
        long SiteId { get; set; }
        bool IsSSLBound { get; set; }
        string IpAddress { get; set; }
        string IpAddressFamily { get; set; }
        string Port { get; set; }
        string Protocol { get; set; }
    }
}