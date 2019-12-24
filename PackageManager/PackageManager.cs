using System.Collections.Generic;
using System.Linq;

namespace DSM.Core.PackageManager
{
    public class PackageManager
    {
        private static readonly PackageManager _manager = null;
        public const int PACKSİZE = 1024 * 1024 * 5;//5 MBytes
        private PackageManager()
        {

        }

        public static PackageManager GetManager()
        {
            return _manager ?? new PackageManager();
        }

        public IEnumerable<IEnumerable<T>> GetPacks<T>(IEnumerable<T> fullObject, int packageSize = PACKSİZE) 
        {
            if (fullObject == null)
            {
                return null;
            }

            long sizeOfObject = fullObject.First().SizeOf();
            int objectCount = fullObject.Count();
            int packLength = (int)(packageSize / sizeOfObject);

            IEnumerable<IEnumerable<T>> packs = fullObject.Where((x, i) => i % packLength == 0)
                .Select((x, i) => fullObject.Skip(i * packLength).Take(packLength));

            return packs;
        }
    }
}