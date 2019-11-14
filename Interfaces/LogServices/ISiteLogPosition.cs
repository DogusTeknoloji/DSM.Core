using System;

namespace DSM.Core.Interfaces.LogServices
{
    public interface ISiteLogPosition
    {
        long Id { get; set; }
        long SiteId { get; set; }
        string FilePath { get; set; }
        long CursorPointer { get; set; }
        long FileSize { get; set; }
        long Transfered { get; set; }
        DateTime LastPackage { get; set; }
        string States { get; set; }
    }
}
