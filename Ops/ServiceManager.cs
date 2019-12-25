using DSM.Core.Models.Management;
using System;

namespace DSM.Core.Ops
{
    public static class ServiceManager
    {
        private static void NewClient(string apiKey)
        {
            string machineName = Environment.MachineName;
            Client client = new Client
            {
                AgentInstallDate = DateTime.Now,
                IsOnline = true,
                LastDataReceived = DateTime.Now,
                LastOnlineDate = DateTime.Now,
                Name = machineName
            };
            _ = WebOperations.WebPost(client, WebOperations.WebMethod.POST_CLIENT, apiKey);
        }

        public static ServiceTimer GetScheduler(short serviceId, int clientId, string apiKey)
        {
            ServiceTimer scheduler = WebOperations.WebGet<ServiceTimer>(WebOperations.WebMethod.GET_SCHEDULER_BY_CLIENTID_AND_SERVICEID, apiKey, clientId, serviceId);
            return scheduler ?? FileOperations.GetLocalScheduler(serviceId) as ServiceTimer; // (scheduler'i return et null mu??) Local Scheduler'i return et
        }

        public static ServiceTimer GetScheduler(short serviceId, string apiKey)
        {
            Client referenceClient = GetClient(apiKey);
            ServiceTimer scheduler = WebOperations.WebGet<ServiceTimer>(WebOperations.WebMethod.GET_SCHEDULER_BY_CLIENTID_AND_SERVICEID, apiKey, referenceClient.Id, serviceId);
            return scheduler ?? FileOperations.GetLocalScheduler(serviceId) as ServiceTimer;
        }

        public static Client GetClient(string apiKey)
        {
            string machineName = Environment.MachineName;
            Client client = WebOperations.WebGet<Client>(WebOperations.WebMethod.GET_CLIENT_BY_MACHINE_NAME, apiKey, machineName);
            NewClient(apiKey);
            return client;
        }


    }
}
