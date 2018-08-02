using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Messages {
    public class MessagingService {
        private readonly IServiceBus _serviceBus;

        public MessagingService() {
        }

        public static void SendMessageToHost(DefaultHost host, string message) {
            var bus = host.Bus as IServiceBus;
            bus.Send(new HelloWorldMessage
            {
                Content = message
            });
        }


        public static void SendMessageToClients(IServiceBus bus, string message) {
            bus.Publish(new HelloWorldResponse {
                Content = message
            });
        }
    }
}
