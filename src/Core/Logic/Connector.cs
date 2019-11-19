using HC.Core.Design;

namespace HC.Core.Logic
{
  public class Connector
  {
    private readonly IDataSource _dataSource;

    private readonly ICommandSink _commandSink;

    public Connector(IDataSource dataSource, ICommandSink command)
    {
      _dataSource = dataSource;
      _commandSink = command;

      _dataSource.DataUpdated += OnDataUpdated;
    }

    private void OnDataUpdated(IDataSource dataSource, IData newData)
    {
      SendCommand(newData);
    }

    private void SendCommand(IData data)
    {
      _commandSink.ProcessCommand(data);
    }
  }
}
