using System;

namespace DSM.Core.Ops.ConsoleTheming
{
    public abstract class ConsoleColorSet<T> : IConsoleColorSet where T : class
    {
        protected static T _instance = null;
        public abstract ConsoleColor BackgroundColor { get; }
        public abstract ConsoleColor ForegroundColor { get; }
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Activator.CreateInstance(typeof(T), true) as T;
                }
                return _instance;
            }
        }
    }
}
