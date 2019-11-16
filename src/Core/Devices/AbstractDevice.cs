using System;
using HC.Core.Design;

namespace HC.Core.Devices
{
  public abstract class AbstractDevice
  {
    private readonly ICommandSink _commandSink;
    private readonly ILog _logger;

    public string Id { get; private set; }

    protected AbstractDevice(string id, ILog logger)
    {
      Id = id;
      _logger = logger;
    }

    protected AbstractDevice(string id, ILog logger, ICommandSink commandSink) : this(id, logger)
    {
      _commandSink = commandSink;
      _logger = logger;
    }

    protected void ProcessCommand(Command command)
    {
      if (_commandSink == null)
        throw new InvalidOperationException("Cannot process commands when commandSink is not set");

      _logger.Notice($"{this} Processing command {command}");
      _commandSink.ProcessCommand(command);
    }

    public override string ToString()
    {
      return $"Device [Id={Id}]";
    }
  }
}