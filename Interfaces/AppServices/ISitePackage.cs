namespace DSM.Core.Interfaces.AppServices
{
    public interface ISitePackage
    {
        long SiteId { get; set; }
        string Name { get; set; }
        string Version { get; set; }
    }
}
