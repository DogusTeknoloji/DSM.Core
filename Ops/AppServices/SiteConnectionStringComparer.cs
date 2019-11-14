using DSM.Core.Models;
using System.Collections.Generic;

namespace DSM.Core.Ops.AppServices
{
    public class SiteConnectionStringComparer : IEqualityComparer<SiteConnectionString>
    {
        public bool Equals(SiteConnectionString x, SiteConnectionString y)
        {
            return x.SiteId == y.SiteId
                && x.ServerName == y.ServerName
                && x.DatabaseName == y.DatabaseName
                && x.ConnectionName == y.ConnectionName;
        }

        public int GetHashCode(SiteConnectionString obj)
        {
            return obj.GetHashCode();
        }
    }
}
