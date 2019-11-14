using System;

namespace DSM.Core.Ops.ConsoleTheming
{
    public class ConsoleColorSetDefault : ConsoleColorSet<ConsoleColorSetDefault>
    {
        private ConsoleColorSetDefault()
        {
        }
        public override ConsoleColor BackgroundColor => ConsoleColor.Black;

        public override ConsoleColor ForegroundColor => ConsoleColor.White;
    }
}
