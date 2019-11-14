using System;

namespace DSM.Core.Ops.ConsoleTheming
{
    public class ConsoleColorSetBlueW : ConsoleColorSet<ConsoleColorSetBlueW>
    {
        private ConsoleColorSetBlueW()
        {

        }
        public override ConsoleColor BackgroundColor => ConsoleColor.Blue;

        public override ConsoleColor ForegroundColor => ConsoleColor.White;
    }
}
