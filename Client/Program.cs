using System;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace Client {
    class Program {
        static void Main(string[] args) {
            // arguments
            if (args.Length == 0) {
                Console.WriteLine("ERROR: missing repeat parameter.");
                Console.ReadLine();
                return;
            }
            int repeat = int.Parse(args[0]);

            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E3.Client", QueueType.Standard);

            var host = new DefaultHost();
            host.Start<ClientBootStrapper>();

            Console.WriteLine("Client 1: Hit enter to send message");

            SendMessages(repeat, host);
            Console.ReadLine();
        }

        private static async System.Threading.Tasks.Task SendMessages(int repeat, DefaultHost host) {
            // step 1: send hello world
            for (int i = 0; i < repeat; i++) {
                MessagingService.SendMessageToHost(host, string.Format("message from client:{0}", i));
                await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
