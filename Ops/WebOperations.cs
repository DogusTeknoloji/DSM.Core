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
        private static string serverUrl = "http://10.236.51.40:90";

        private static readonly LogManager logManager = LogManager.GetManager("WebOperations");
        public static string AuthenticateAgent(string AgentName, string ServerName)
        {
            try
            {
#if DEBUG
                WebRequest request = WebRequest.CreateHttp($"http://{Extensions.GetLocalIPAddress()}:90/Auth/Login/");
#else
                WebRequest request = WebRequest.CreateHttp($"{serverUrl}/Auth/Login/");
#endif
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                //string requestBody = JsonConvert.SerializeObject(new { Username = ServerName, Password = AgentName });
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
                throw ex;
            }
        }

        public static T WebGet<T>(string method, string apiKey, params object[] parameters)
        {
            try
            {
#if DEBUG
                WebRequest request = WebRequest.CreateHttp($"http://{Extensions.GetLocalIPAddress()}:90/{method}/{string.Join("/", parameters)}?NGAuthVKey={apiKey}");
#else
                WebRequest request = WebRequest.CreateHttp($"{serverUrl}/{method}/{string.Join("/", parameters)}?NGAuthVKey={apiKey}");
#endif
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
                logManager.Write(ex.Message);
                logManager.Write(ex.StackTrace);
                logManager.Write(ex.HResult.ToString());
                logManager.Write(ex.Source);
                logManager.Write(ex.Data.ToString());
                logManager.Write(ex.Response.ResponseUri.AbsoluteUri);
                XConsole.WriteLine(ex.ToString(), ConsoleTheming.ConsoleColorSetRed.Instance);
                XConsole.WriteLine(ex.Response.ResponseUri.AbsoluteUri, ConsoleTheming.ConsoleColorSetRed.Instance);
                return default;
            }
        }

        private static bool silencioFlag = true;
        public static T WebPost<T>(T bodyItem, string method, string apiKey) where T : class
        {
            try
            {
                if (!silencioFlag)
                {
                    XConsole.SilentAll(includeMethods: true);
                }

                silencioFlag = true;
#if DEBUG
                WebRequest request = WebRequest.CreateHttp($"http://{Extensions.GetLocalIPAddress()}:90/{method}/?NGAuthVKey={apiKey}");
#else
                WebRequest request = WebRequest.CreateHttp($"{serverUrl}/{method}/?NGAuthVKey={apiKey}");
#endif
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
                logManager.Write(ex.Message);
                logManager.Write(ex.StackTrace);
                logManager.Write(ex.HResult.ToString());
                logManager.Write(ex.Source);
                logManager.Write(ex.Data.ToString());
                XConsole.WriteLine(ex.ToString(), ConsoleTheming.ConsoleColorSetRed.Instance);
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
                //XConsole.WriteLine($"TRYING TO CONNECT {uri} DESTINATION BY {port} PORT");

                HttpWebRequest request = WebRequest.CreateHttp(uri.Trim());
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                endpoint.ServerResponse = (int)response.StatusCode;
                endpoint.ServerResponseDescription = response.StatusDescription;
                endpoint.HttpProtocol = response.ProtocolVersion.ToString();
                endpoint.HostInformation = response.Server;

                ProcessDNSInformation(response.ResponseUri.Host, ref endpoint);

                //XConsole.WriteLine($"DESTINATION HOST {endpoint.DestinationServer} REPLIED --> {endpoint.ServerResponseDescription}[{endpoint.ServerResponse}] WITH HTTP {endpoint.HttpProtocol} ");
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                //XConsole.WriteLine($"EXCEPTION--> {uri}{Environment.NewLine} MSG --> {ex.Message}");
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
        public static bool CheckSQLDatabaseAccesibility(string connectionString)
        {
            SqlConnection connection = null;
            if (connectionString == null) return false;
            try
            {
                connection = new SqlConnection(connectionString);
                var task = Task.Run(() =>
                {
                    logManager.Write("Task Running:" + connectionString);
                    connection.Open();
                    connection.Close();
                });

                return task.Wait(TimeSpan.FromSeconds(60));
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