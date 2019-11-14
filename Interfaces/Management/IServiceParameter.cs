namespace DSM.Core.Interfaces.Management
{
    public interface IServiceParameter
    {
        string Name { get; set; }
        string Value { get; set; }
        bool IsActive { get; set; }
        bool IsObsolete { get; set; }
        short ServiceId { get; set; }
    }
}
