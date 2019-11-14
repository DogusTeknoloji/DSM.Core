namespace DSM.Core.Ops
{
    public static class FileSize
    {
        private const int COEFFICIENT = 1024;

        public const long BIT = 1;
        public const long BYTE = 8 * BIT;
        public const long KB = COEFFICIENT * BYTE;
        public const long MB = COEFFICIENT * KB;
        public const long GB = COEFFICIENT * MB;
        public const long TB = COEFFICIENT * GB;
    }
}
