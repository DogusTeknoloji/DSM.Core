using System;

namespace DSM.Core.Ops.ConsoleTheming
{
    public class ConsoleColorSetGreen : ConsoleColorSet<ConsoleColorSetGreen>
    {
        private ConsoleColorSetGreen()
        {

        }
        public override ConsoleColor BackgroundColor => ConsoleColor.Black;

        public override ConsoleColor ForegroundColor => ConsoleColor.Green;
    }
}
