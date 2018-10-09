using GreenPipes;
using MassTransit;
using System;

namespace MTTest
{
  class Program
  {
    static void Main(string[] args)
    {
      var bus = CreateBus();

      bus.Publish(new MyMessage());

      Console.WriteLine("Hit any key to exit.");
      Console.ReadKey();
    }

    private static IBusControl CreateBus()
    {
      var bus = Bus.Factory.CreateUsingInMemory(config =>
      {
        config.UseInMemoryScheduler();

        config.ReceiveEndpoint("MySubscription", ep =>
        {
          ep.Handler<MyMessage>(
            context => {
              throw new Exception();
            },
            cnfg =>
            {
              cnfg.UseScheduledRedelivery(r => r.Immediate(2));
            });
        });
      });

      bus.ConnectConsumeObserver(new MyObserver());

      bus.Start();

      return bus;
    }
  }
}
