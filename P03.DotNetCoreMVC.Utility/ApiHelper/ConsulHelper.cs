using System;
using System.Collections.Generic;
using System.Text;
using Consul;
using Microsoft.Extensions.Configuration;

namespace P03.DotNetCoreMVC.Utility.ApiHelper
{
    public static class ConsulHelper
    {

        public static void ConsulRegister(this IConfiguration configuration)
        {
            ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            });

            string ip = configuration["ip"];
            int port = int.Parse(string.IsNullOrWhiteSpace(configuration["port"])? "44357": configuration["port"]);// commandline 
            int weight = string.IsNullOrWhiteSpace(configuration["weight"]) ? 1 : int.Parse(configuration["weight"]);

            string serviceId = "service" +ip+"Port"+port;//same ip and port will be one service, overwrite when reload

            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = serviceId,
                Name = "UserServiceGroup",//group name
                Address = ip,
                Port = port,
                Tags = new string[] {weight.ToString()}
                ,
                Check = new AgentServiceCheck()//heart beating monitor.
                {
                    Interval = TimeSpan.FromSeconds(12),
                    HTTP = $"http://{ip}:{port}/api/HealthCheck/Index",
                    Timeout = TimeSpan.FromSeconds(5),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5)
                }
            });
            Console.WriteLine($"http://{ip}:{port} finish registering with service ID: {serviceId} ");
        }

    }
}
