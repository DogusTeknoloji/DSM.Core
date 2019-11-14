using DSM.Core.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace DSM.Core.Ops
{
    public static class Extensions
    {
        public static string ToLowerFirstChar(this string input)
        {
            string newString = input;
            if (!string.IsNullOrEmpty(newString) && char.IsUpper(newString[0]))
            {
                newString = char.ToLower(newString[0]) + newString.Substring(1);
            }

            return newString;
        }
        public static string GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static Dictionary<string, object> UseForPost<T>(this T ins)
        {
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            System.Reflection.PropertyInfo[] properties = ins.GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                bool IsTaggedWithNotMapped = properties[i]
                    .GetCustomAttributes(true)
                    .Any(a => a.GetType() == typeof(ExcludeFromDataModelAttribute) || a.GetType() == typeof(DatabaseGeneratedAttribute));

                if (!IsTaggedWithNotMapped)
                {
                    keyValuePairs.Add(properties[i].Name, ins.GetType().GetProperty(properties[i].Name).GetValue(ins, null));
                }
            }
            return keyValuePairs;
        }
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        public static IEnumerable<object> DeserializeFromJson<T>(this JArray obj)
        {
            Type innerType = typeof(T).GenericTypeArguments[0];

            IList<object> list = new List<object>();
            obj.ToList().ForEach(x => list.Add(x.ToObject(innerType)));

            return list;
        }
    }
}
