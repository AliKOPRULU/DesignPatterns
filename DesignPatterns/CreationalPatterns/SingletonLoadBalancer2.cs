using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
    class SingletonLoadBalancer2
    {
        static void Main(string[] args)
        {
            LoadBalancer2 b1 = LoadBalancer2.GetLoadBalancer();
            LoadBalancer2 b2 = LoadBalancer2.GetLoadBalancer();
            LoadBalancer2 b3 = LoadBalancer2.GetLoadBalancer();
            LoadBalancer2 b4 = LoadBalancer2.GetLoadBalancer();

            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            LoadBalancer2 balancer = LoadBalancer2.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string serverName = balancer.NextServer.Name;
                string serverIP = balancer.NextServer.IP;
                Console.WriteLine("Dispatch Request to : " + serverName + "   -->  " + serverIP);
            }

            Console.ReadKey();
        }
    }

    sealed class LoadBalancer2
    {
        // Static members are 'eagerly initialized', that is, 
        // immediately when class is loaded for the first time.
        // .NET guarantees thread safety for static initialization

        private static readonly LoadBalancer2 _instance = new LoadBalancer2();

        private List<Server> _servers;
        private Random _random = new Random();

        private LoadBalancer2()
        {
            _servers = new List<Server>
            {
                new Server{ Name = "ServerI", IP = "120.14.220.18" },
                new Server{ Name = "ServerII", IP = "120.14.220.19" },
                new Server{ Name = "ServerIII", IP = "120.14.220.20" },
                new Server{ Name = "ServerIV", IP = "120.14.220.21" },
                new Server{ Name = "ServerV", IP = "120.14.220.22" },
            };
        }

        public static LoadBalancer2 GetLoadBalancer()
        {
            return _instance;
        }

        public Server NextServer
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }

    }

    class Server
    {
        public string Name { get; set; }

        public string IP { get; set; }
    }

}
