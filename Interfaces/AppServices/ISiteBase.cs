namespace DSM.Core.Interfaces.AppServices
{
    public interface ISiteBase
    {
        string Name { get; set; }
        string ApplicationPoolName { get; set; }
        string EnabledProtocols { get; set; }
        string PhysicalPath { get; set; }
    }
}
