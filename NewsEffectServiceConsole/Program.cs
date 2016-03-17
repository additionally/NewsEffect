using NewsEffectService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace NewsEffectServiceConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WelcomeService)))
            {
                string address = "http://" + Dns.GetHostName() + ":8081/";
                
                host.AddServiceEndpoint(typeof(IWelcomeService), new BasicHttpBinding(), address);
                host.Open();
                
                Console.WriteLine("Press any key to stop hosting");

                Console.ReadLine();
            }
        }
    }
}
