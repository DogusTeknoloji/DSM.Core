using DSM.Core.Interfaces.AppServices;
using DSM.Core.Interfaces.LogServices;
using DSM.Core.Models;
using DSM.Core.Models.LogServices;
using System;
using System.Collections.Generic;

namespace DSM.Core.Ops
{
    public static class WebTransfer
    {
        private static string _authToken = null;
        public static void Authorize(string apiKey)
        {
            _authToken = apiKey;
        }

        public static Site GetSite(long siteId)
        {
            return WebOperations
                .WebGet<Site>(WebOperations.WebMethod.GET_SITE_BY_ID,
                              _authToken, siteId);
        }

        public static SiteBinding GetSiteBinding(long siteId)
        {
            return WebOperations
                .WebGet<SiteBinding>(WebOperations.WebMethod.GET_BINDING_BY_SITEID,
                                     _authToken, siteId);
        }

        public static SiteConnectionString GetConnectionString(long siteId)
        {
            return WebOperations
                .WebGet<SiteConnectionString>(WebOperations.WebMethod.GET_CONNECTION_STRING_BY_SITEID,
                                              _authToken, siteId);
        }

        public static IEnumerable<SiteConnectionString> GetSiteConnectionStrings(long siteId)
        {
            return WebOperations
                .WebGet<IEnumerable<SiteConnectionString>>(WebOperations.WebMethod.GET_CONNECTION_STRINGS_BY_SITEID,
                                                           _authToken, siteId);
        }

        public static SiteEndpoint GetSiteEndpoint(long siteId)
        {
            return WebOperations
                .WebGet<SiteEndpoint>(WebOperations.WebMethod.GET_ENDPOINT_BY_SITEID,
                                       _authToken, siteId);
        }

        public static SiteLog GetSiteLog(long siteId)
        {
            return WebOperations
                .WebGet<SiteLog>(WebOperations.WebMethod.GET_EVENT_LOG_BY_SITEID,
                                 _authToken, siteId);
        }

        public static SiteWebConfiguration GetConfiguration(long siteId)
        {
            return WebOperations
                   .WebGet<SiteWebConfiguration>(WebOperations.WebMethod.GET_WEB_CONFIGURATION_BY_SITEID,
                                                   _authToken, siteId);
        }


        public static IEnumerable<SiteEndpoint> GetSiteEndpoints(long siteId)
        {
            return WebOperations
                .WebGet<IEnumerable<SiteEndpoint>>(WebOperations.WebMethod.GET_ENDPOINTS_BY_SITEID,
                                                    _authToken, siteId);
        }

        public static IEnumerable<SiteLogFilter> GetSiteTransactionFilters()
        {
            return WebOperations
                .WebGet<IEnumerable<SiteLogFilter>>(WebOperations.WebMethod.GET_TRANSACTION_FILTERS,
                                                                        _authToken);
        }

        public static IEnumerable<Site> GetSites(string machineName)
        {
            return WebOperations
                .WebGet<IEnumerable<Site>>(WebOperations.WebMethod.GET_SITES_BY_MACHINENAME,
                                           _authToken, machineName);
        }

        public static bool GetSiteLogActivationStatus()
        {
            return WebOperations
                .WebGet<bool>(WebOperations.WebMethod.GET_TRANSACTION_ACTIVATION_STATUS,
                              _authToken);
        }

        public static ISiteLogPosition GetLogPosition(long siteId)
        {
            return WebOperations
                .WebGet<ISiteLogPosition>(WebOperations.WebMethod.GET_SITE_LOG_POSITON,
                                           _authToken, siteId);
        }

        public static DateTime GetSiteLogLastLogDate(long siteId)
        {
            return WebOperations
                .WebGet<DateTime>(WebOperations.WebMethod.GET_TRANSACTION_LASTLOGDATE_BY_SITEID,
                                  _authToken, siteId);
        }

        public static Site PostSite(Site item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_SITE, _authToken);
        }

        public static IEnumerable<Site> PostSite(IEnumerable<Site> item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_SITE_MULTIPLE, _authToken);
        }
        public static SiteBinding PostSiteBinding(SiteBinding item)
        {
            return WebOperations
                 .WebPost(item, WebOperations.WebMethod.POST_BINDING_MULTIPLE, _authToken);
        }

        public static IEnumerable<SiteBinding> PostSiteBinding(IEnumerable<SiteBinding> item)
        {
            return WebOperations
                 .WebPost(item, WebOperations.WebMethod.POST_BINDING_MULTIPLE, _authToken);
        }

        public static SiteConnectionString PostSiteConnectionString(SiteConnectionString item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_CONNECTION_STRING, _authToken);
        }

        public static IEnumerable<SiteConnectionString> PostSiteConnectionString(IEnumerable<SiteConnectionString> item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_CONNECTION_STRING_MULTIPLE, _authToken);
        }

        public static SiteEndpoint PostSiteEndpoint(SiteEndpoint item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_ENDPOINT, _authToken);
        }

        public static IEnumerable<SiteEndpoint> PostSiteEndpoint(IEnumerable<SiteEndpoint> item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_ENDPOINT_MULTIPLE, _authToken);
        }

        public static SiteEventLog PostSiteEventLog(SiteEventLog item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_EVENT_LOG, _authToken);
        }

        public static IEnumerable<SiteEventLog> PostSiteEventLog(IEnumerable<SiteEventLog> item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_EVENT_LOG_MULTIPLE, _authToken);
        }

        public static SitePackage PostSitePackage(SitePackage item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_PACKAGE, _authToken);
        }
        public static IEnumerable<SitePackage> PostSitePackage(IEnumerable<SitePackage> item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_PACKAGE_MULTIPLE, _authToken);
        }

        public static ISiteTracker PostSiteTracker(ISiteTracker item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_SITE_TRACKER, _authToken);
        }
        public static IEnumerable<ISiteTracker> PostSiteTracker(IEnumerable<ISiteTracker> item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_SITE_TRACKER_MULTIPLE, _authToken);
        }

        public static SiteLog PostSiteLog(SiteLog item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_TRANSACTION, _authToken);
        }

        public static IEnumerable<SiteLog> PostSiteLog(IEnumerable<SiteLog> item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_TRANSACTION_MULTIPLE, _authToken);
        }

        public static SiteWebConfiguration PostSiteWebConfiguration(SiteWebConfiguration item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_WEB_CONFIGURATION, _authToken);
        }

        public static IEnumerable<SiteWebConfiguration> PostSiteWebConfiguration(IEnumerable<SiteWebConfiguration> item)
        {
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_WEB_CONFIGURATION_MULTIPLE, _authToken);
        }

        public static IEnumerable<object> PostMail(IISMailQueue mail)
        {
            IEnumerable<IISMailQueue> item = new[] { mail };
            return WebOperations
                .WebPost(item, WebOperations.WebMethod.POST_MAIL_TO_QUEUE, _authToken);
        }

    }
}
