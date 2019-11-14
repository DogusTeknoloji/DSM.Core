namespace DSM.Core.Interfaces.Management
{
    public interface IServiceTimer
    {
        short ServiceId { get; set; }
        int CilentId { get; set; }
        short Day { get; set; }
        short Hour { get; set; }
        short Minute { get; set; }
        short Second { get; set; }
        bool IsActive { get; set; }
    }
}