using System;

namespace DSM.Core.Ops.ConsoleTheming
{
    public class ConsoleColorSetBlue : ConsoleColorSet<ConsoleColorSetBlue>
    {
        private ConsoleColorSetBlue()
        {

        }
        public override ConsoleColor BackgroundColor => ConsoleColor.Black;

        public override ConsoleColor ForegroundColor => ConsoleColor.Blue;
    }
}
