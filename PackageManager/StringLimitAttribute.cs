using System;

namespace DSM.Core.PackageManager
{
    public class StringLimitAttribute : Attribute
    {
        public int MaxLength { get; set; }
        public StringLimitAttribute(int maximumLength)
        {
            MaxLength = maximumLength;
        }

    }
}
