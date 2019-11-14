namespace DSM.Core.PackageManager
{
    public static class Extensions
    {
        public static string Limit(this string value, int length)
        {
            if (value?.Length > length)
            {
                return value.Substring(0, length);
            }
            return value;
        }
    }
}
