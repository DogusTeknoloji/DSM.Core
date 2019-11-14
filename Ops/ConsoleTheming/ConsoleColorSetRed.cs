using System;

namespace DSM.Core.Ops.ConsoleTheming
{
    public class ConsoleColorSetRed : ConsoleColorSet<ConsoleColorSetRed>
    {
        private ConsoleColorSetRed()
        {

        }
        public override ConsoleColor BackgroundColor => ConsoleColor.Black;

        public override ConsoleColor ForegroundColor => ConsoleColor.Red;
    }
}
