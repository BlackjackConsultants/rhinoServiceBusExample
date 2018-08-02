using System;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace Client {
    class Program {
        static void Main(string[] args) {
            int repeat=100;
            string machineName = "msmq://localhost/";
            string queueName = "LearningRhinoESB.E3.Client";
            // argument 1: repeat
            if (args.Length == 1) {
                repeat = int.Parse(args[0]);
            }
            // argument 2: machine name
            if (args.Length == 2) {
                machineName = args[1];
            }
            // argument 3: queue name
            if (args.Length == 3) {
                queueName = args[2];
            }
            // prepare queue
            PrepareQueues.Prepare(string.Format("{0}{1}",machineName, queueName), QueueType.Standard);
            var host = new DefaultHost();
            host.Start<ClientBootStrapper>();
            string machineId = string.Format("{0}/{1}", machineName, Guid.NewGuid());
            SendMessages(repeat, host, machineId);
            Console.WriteLine("Client 1: Hit enter to send message");
            Console.ReadLine();
        }

        private static async System.Threading.Tasks.Task SendMessages(int repeat, DefaultHost host, string machineid) {
            // step 1: send hello world
            for (int i = 0; i < repeat; i++) {
                MessagingService.SendMessageToHost(host, string.Format("{0}:{1}", machineid, i));
                await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
