using System;
using Messages;
using Rhino.ServiceBus;

namespace Backend {
    public class HelloWorldConsumer : ConsumerOf<HelloWorldMessage> {
        private readonly IServiceBus _serviceBus;

        public HelloWorldConsumer(IServiceBus serviceBus) {
            _serviceBus = serviceBus;
        }

        public void Consume(HelloWorldMessage message) {
            // Step 2: server receive message from client
            Console.WriteLine(message.Content);

            // Step 3: send back to client
            _serviceBus.Publish(new HelloWorldResponse {
                Content = "Well, hello back from server!!!"
            });

            //_serviceBus.Publish(new MessageWithoutSubscriber());
            //_serviceBus.Notify(new MessageWithoutSubscriber());
        }
    }
}