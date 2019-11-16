using System;
using HC.Core.Design;

namespace HC.Core.Logic
{
  public class CommandSink : ICommandSink
  {
    public ILog _logger;

    private readonly ICommandConsumer _commandConsumer;

    public string Id { get; private set; }

    public CommandSink(string id, ILog logger, ICommandConsumer commandConsumer)
    {
      Id = id;
      _logger = logger;
      _commandConsumer = commandConsumer;
    }

    public void ProcessCommand(IData commandData)
    {
      var command = new Command(Id, commandData);
      _logger.Notice($"Processing {command}");
      _commandConsumer.Consume(command);
    }

    public override string ToString()
    {
      return $"CommandSink [Id={Id}]";
    }
  }
}
