using HC.Core.Design;
using System;

namespace HC.Core.Devices
{
  public abstract class AbstractDevice
  {
    private ICommandSink _commandSink;

    public string Id { get; private set; }

    protected AbstractDevice(string id) => Id = id;

    protected AbstractDevice(string id, ICommandSink commandSink) : this(id)
    {
      _commandSink = commandSink;
    }

    protected void ProcessCommand(Command command)
    {
      if (_commandSink == null)
        throw new InvalidOperationException("Cannot process commands when commandSink is not set");

      _commandSink.ProcessCommand(command);
    }
  }
}