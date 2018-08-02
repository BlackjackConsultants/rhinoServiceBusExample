using System;
using Messages;
using Rhino.ServiceBus;

namespace Client
{
    public class HelloWorldResponseConsumer : ConsumerOf<HelloWorldResponse>
    {
        public void Consume(HelloWorldResponse message) {
            // step 4: receive message from server
            Console.WriteLine(message.Content);
        }
    }
}