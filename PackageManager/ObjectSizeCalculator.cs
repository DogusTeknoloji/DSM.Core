using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace DSM.Core.PackageManager
{
    public static class ObjectSizeCalculator
    {
        public static long SizeOf(this object value)
        {
            long size = 0;

            if (value == null)
            {
                return 0;
            }

            Type valueType = value.GetType();
            FieldInfo[] fields = valueType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo field in fields)
            {
                size += field.SizeOf(value);
            }
            return size;
        }

        public static long SizeOf(this FieldInfo field, object value)
        {
            Type type = field.FieldType;
            if (type.IsValueType && type != typeof(DateTime))
            {
                return Marshal.SizeOf(type);
            }
            else if (type.IsArray)
            {
                IEnumerable array = value as IEnumerable;
                return array.SizeOf();
            }
            else if (type == typeof(string))
            {
                StringLimitAttribute attribute = field.GetCustomAttribute<StringLimitAttribute>();
                return attribute.SizeOf();
            }
            else if (type == typeof(DateTime))
            {
                return 4;// + 2;
            }
            else
            {
                return 0;
            }
        }

        public static long SizeOf(this IEnumerable enumerable)
        {
            if (enumerable == null)
            {
                return 0;
            }

            IEnumerable<object> ienr = enumerable.Cast<object>();
            Type elementType = enumerable.GetType().GetElementType();
            long elementSize = ienr.FirstOrDefault().SizeOf();

            long totalSize = elementSize * ienr.Count();
            return totalSize;
        }

        public static long SizeOf(this StringLimitAttribute attribute)
        {
            if (attribute == null)
            {
                return 0;
            }

            int charSize = Marshal.SizeOf<char>();
            int length = attribute.MaxLength;

            long totalSize = charSize * length;//+ 16 + 4 + 1;
            return totalSize;
        }
    }
}
