using DSM.Core.Models;
using Newtonsoft.Json;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DSM.Core.Ops
{
    public static class WebOperations
    {

#if DEBUG
        private static string _serverUrl = AppSettingsManager.GetConfiguration()["Host:Url"];
#else 
        private static string _serverUrl = AppSettingsManager.GetConfiguration()["Host:Url"];
#endif

        private static readonly LogManager _logManager = LogManager.GetManager("WebOperations");
        public static string AuthenticateAgent(string AgentName, string ServerName)
        {
            try
            {
                WebRequest request = WebRequest.CreateHttp($"{_serverUrl}/Auth/Login/");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                string requestBody = $"Username={ServerName}&Password={AgentName}";
                byte[] buffer = Encoding.UTF8.GetBytes(requestBody);
                Stream body = request.GetRequestStream();

                body.Write(buffer, 0, buffer.Length);
                WebResponse response = request.GetResponse();

                StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string incMsg = responseStream.ReadToEnd();
                dynamic json = JsonConvert.DeserializeObject<object>(incMsg);
                string apiKey = (string)json.apiKey;

                return apiKey;
            }
            catch (Exception ex)
            {
                throw new Exception("Authentication Fail", ex);
            }
        }

        public static T WebGet<T>(string method, params object[] parameters)
        {
            try
            {
                string requestParameters = string.Join("/", parameters);
                string requestString = string.Join("/", _serverUrl, method);
                if (requestParameters.Length > 0) requestString = string.Join("/", requestString, requestParameters);


                WebRequest request = WebRequest.CreateHttp(requestString);
                request.Method = "GET";
                request.ContentType = "application/json";

                WebResponse response = request.GetResponse();

                StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string incMsg = responseStream.ReadToEnd();
                T json = JsonConvert.DeserializeObject<T>(incMsg);
                return json;
            }
            catch (WebException ex)
            {
                ExceptionHandler.WebException(ex);
                return default;
            }
            catch (JsonException ex)
            {
                ExceptionHandler.JsonException(ex);
                return default;
            }
        }

        public static T WebGet<T>(string method, string apiKey, params object[] parameters)
        {
            try
            {
                WebRequest request = WebRequest.CreateHttp($"{_serverUrl}/{method}/{string.Join("/", parameters)}?NGAuthVKey={apiKey}");
                request.Method = "GET";
                request.ContentType = "application/json";

                WebResponse response = request.GetResponse();

                StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string incMsg = responseStream.ReadToEnd();
                T json = JsonConvert.DeserializeObject<T>(incMsg);
                return json;
            }
            catch (WebException ex)
            {
                ExceptionHandler.WebException(ex);
                return default;
            }
            catch (JsonException ex)
            {
                ExceptionHandler.JsonException(ex);
                return default;
            }
        }

        private static bool _silencioFlag = true;
        public static T WebPost<T>(T bodyItem, string method, string apiKey) where T : class
        {
            try
            {
                if (!_silencioFlag)
                {
                    XConsole.SilentAll(includeMethods: true);
                }

                _silencioFlag = true;

                WebRequest request = WebRequest.CreateHttp($"{_serverUrl}/{method}/?NGAuthVKey={apiKey}");
                request.Method = "POST";
                request.ContentType = "application/json";
                string requestBody = JsonConvert.SerializeObject(bodyItem);

                byte[] buffer = Encoding.UTF8.GetBytes(requestBody);
                Stream body = request.GetRequestStream();
                body.Write(buffer, 0, buffer.Length);
                WebResponse response = request.GetResponse();

                StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

                string incMsg = responseStream.ReadToEnd();

                T retval = (T)JsonConvert.DeserializeObject(incMsg, typeof(T));

                return retval;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Exception(ex);
                return default;
            }
        }

        public static bool VerifyConnectionAvailability(string address, int port)
        {
            XConsole.WriteLine($"Verifying Connection for {address}");
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(address, port);
            bool socketIsConnected = socket.Connected;
            XConsole.WriteLine($"Current Connection State: {socketIsConnected}");
            if (socketIsConnected)
            {
                socket.Disconnect(true);
            }

            socket.Dispose();
            return socketIsConnected;
        }

        public static bool CheckUriAvailability(string uri, int port, ref SiteEndpoint endpoint)
        {
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(uri.Trim());
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                endpoint.ServerResponse = (int)response.StatusCode;
                endpoint.ServerResponseDescription = response.StatusDescription;
                endpoint.HttpProtocol = response.ProtocolVersion.ToString();
                endpoint.HostInformation = response.Server;

                ProcessDNSInformation(response.ResponseUri.Host, ref endpoint);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                endpoint.ServerResponseDescription = ex.Message;
            }
            return false;
        }

        public static void ProcessDNSInformation(string host, ref SiteEndpoint endpoint)
        {
            IPHostEntry hostInfo = Dns.GetHostEntry(host);
            IPAddress address = hostInfo.AddressList.FirstOrDefault();
            endpoint.DestinationAddress = address.ToString();
            endpoint.DestinationAddressType = address?.AddressFamily.ToString();
            endpoint.DestinationServer = hostInfo.HostName;
        }
        public static async Task<bool> CheckSQLDatabaseAccesibilityAsync(string connectionString)
        {
            SqlConnection connection = null;
            if (connectionString == null) return false;
            try
            {
                connection = new SqlConnection(connectionString);
                var task = Task.Run(new Func<bool>(() =>
              {
                  _logManager.Write("Task Running:" + connectionString);
                  connection.Open();
                  connection.Close();
                  return true;
              }));

                return await task.ConfigureAwait(false);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public struct WebMethod
        {
            public const string GET_ENDPOINT_ALL = "endpoints";
            public const string GET_SITES_ALL = "sites";
            public const string GET_MAILS_ALL = "mails";
            public const string GET_MAIL_RECIPIENTS = "mailrecipients";

            public const string GET_CLIENT_LIST = "clientList";
            public const string GET_ENDPOINTS_BY_SITEID = "endpointlist";
            public const string GET_SITES_BY_MACHINENAME = "sitesList";
            public const string GET_CONNECTION_STRINGS_BY_SITEID = "connectionstringlist";
            public const string GET_TRANSACTIONS_BY_MACHINENAME = "IISTransactions";
            public const string GET_TRANSACTION_FILTERS = "IISTransactions/Filter";
            public const string GET_ADDOMAINUSER_LIST = "addomainuserList";
            public const string GET_ADDOMAIN_LIST = "addomainList";

            public const string GET_CLIENT_BY_MACHINE_NAME = "client";
            public const string GET_SCHEDULER_BY_CLIENTID_AND_SERVICEID = "scheduler";
            public const string GET_SITE_BY_ID = "sites";
            public const string GET_BINDING_BY_SITEID = "bindings";
            public const string GET_EVENT_LOG_BY_SITEID = "logs";
            public const string GET_ENDPOINT_BY_SITEID = "endpoints";
            public const string GET_CONNECTION_STRING_BY_SITEID = "connectionstrings";
            public const string GET_WEB_CONFIGURATION_BY_SITEID = "webconfigurations";
            public const string GET_MAIL_FROM_QUEUE_BY_SITEID = "mail";
            public const string GET_CONFIG_BACKUP_STATUS = "Archive/WebConfig";
            public const string GET_TRANSACTION_LASTLOGDATE_BY_SITEID = "IISTransactions/LastLogDate";
            public const string GET_TRANSACTION_ACTIVATION_STATUS = "IISTransactions/Activation";
            public const string GET_SITE_LOG_POSITON = "IISLog/Position";
            public const string GET_AUTH_IS_VALID = "IsValid";

            public const string POST_SITE = "sites";
            public const string POST_BINDING = "bindings";
            public const string POST_EVENT_LOG = "logs";
            public const string POST_ENDPOINT = "endpoints";
            public const string POST_CONNECTION_STRING = "connectionstrings";
            public const string POST_WEB_CONFIGURATION = "webconfigurations";
            public const string POST_MAIL_TO_QUEUE = "mail";
            public const string POST_CONFIG_TO_BACKUP = "Archive/WebConfig";
            public const string POST_TRANSACTION = "IISTransactions";
            public const string POST_AUTH_LOGIN = "Login";
            public const string POST_AUTH_SIGNUP_AGENT = "SignUpAgent";
            public const string POST_SCHEDULER = "scheduler";
            public const string POST_CLIENT = "client";
            public const string POST_ENABLE_SCHEDULER = "scheduler/Enable";
            public const string POST_DISABLE_SCHEDULER = "scheduler/Disable";
            public const string POST_SITE_TRACKER = "sitetracker";
            public const string POST_ADDOMAIN_USER = "addomainuser";
            public const string POST_PACKAGE = "packageVersion";
            public const string POST_DELETE_MAIL = "maildelete";

            public const string POST_SITE_MULTIPLE = "sites_multi";
            public const string POST_BINDING_MULTIPLE = "bindings_multiple";
            public const string POST_EVENT_LOG_MULTIPLE = "logs_multiple";
            public const string POST_ENDPOINT_MULTIPLE = "endpoints_multiple";
            public const string POST_CONNECTION_STRING_MULTIPLE = "connectionstrings_multiple";
            public const string POST_WEB_CONFIGURATION_MULTIPLE = "webconfigurations_multiple";
            public const string POST_CONFIG_TO_BACKUP_MULTIPLE = "Archive/WebConfig_multiple";
            public const string POST_TRANSACTION_MULTIPLE = "IISTransactions_multiple";
            public const string POST_SITE_TRACKER_MULTIPLE = "sitetracker_multiple";
            public const string POST_ADDOMAIN_USER_MULTIPLE = "addomainuser_multiple";
            public const string POST_PACKAGE_MULTIPLE = "packageVersion_multiple";

            public const string DELETE_AUTH_DESTROY_API = "/";
        }
    }
}