using MassTransit;
using System;
using System.Threading.Tasks;

namespace MTTest
{
  internal class MyObserver : IConsumeObserver
  {
    public MyObserver()
    {

    }

    /// <inheritdoc/>
    async Task IConsumeObserver.PreConsume<T>(ConsumeContext<T> context)
    {
      Console.ForegroundColor = ConsoleColor.Yellow;
      await Console.Out.WriteLineAsync("PreConsume");
      Console.ForegroundColor = ConsoleColor.White;
    }

    /// <inheritdoc/>
    async Task IConsumeObserver.PostConsume<T>(ConsumeContext<T> context)
    {
      Console.ForegroundColor = ConsoleColor.Green;
      await Console.Out.WriteLineAsync("PostConsume");
      Console.ForegroundColor = ConsoleColor.White;
    }

    /// <inheritdoc/>
    async Task IConsumeObserver.ConsumeFault<T>(ConsumeContext<T> context, Exception exception)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      await Console.Out.WriteLineAsync("ConsumeFault");
      Console.ForegroundColor = ConsoleColor.White;
    }
  }
}
