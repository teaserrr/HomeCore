using HC.Core.Design;
using HC.Core.Logic;

namespace HC.Core.Factories
{
  public class CommandSinkFactory : ICommandSinkFactory
  {
    public ICommandSink Create(string id, ILog logger, ICommandConsumer commandConsumer)
    {
      return new CommandSink(id, logger, commandConsumer);
    }
  }
}
