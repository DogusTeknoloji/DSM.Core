using System;

namespace DSM.Core.Ops.ConsoleTheming
{
    public interface IConsoleColorSet
    {
        ConsoleColor BackgroundColor { get; }
        ConsoleColor ForegroundColor { get; }
        
    }
}
