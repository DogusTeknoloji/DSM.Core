namespace DSM.Core.Interfaces.AppServices
{
    public interface ISiteWebConfiguration
    {
        long SiteId { get; set; }
        string ContentRaw { get; set; }
    }
}
