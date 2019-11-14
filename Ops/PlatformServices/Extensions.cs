using System;

namespace DSM.Core.Ops.PlatformServices
{
    public static class Extensions
    {
        public static T Get<T>(this object value)
        {
            if (value != null)
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }

            return default(T);
        }
    }
}
