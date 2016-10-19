using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

            // Step 2 Create a ServiceHost instance
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            try
            {
                // Step 3 Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(ICalculatorService), new WSHttpBinding(), "CalculatorService");

                // Step 4 Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
            finally {
                Console.ReadLine();
            }
        }
    }
}

//using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
//            {
//                host.AddServiceEndpoint(typeof(ICalculatorService), new WSHttpBinding(), "http://127.0.0.1:9999/calculatorservice");
//                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
//                {
//                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
//behavior.HttpGetEnabled = true;
//                    behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/calculatorservice/metadata");
//host.Description.Behaviors.Add(behavior);
//                }
//                host.Opened += delegate
//{
//   Console.WriteLine("CalculaorService已经启动，按任意键终止服务！");
//};

//                host.Open();
//                Console.Read();
//            }
