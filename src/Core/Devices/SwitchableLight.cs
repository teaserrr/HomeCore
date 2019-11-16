using System;
using HC.Core.DataTypes;
using HC.Core.Design;

namespace HC.Core.Devices
{
  public class SwitchableLight : AbstractDevice
  {
    public const string SwitchCommandId = "switchCommand";
    public const string StateDataSourceId = "stateDataSource";
    
    public SwitchableLight(string id, ILog logger, IDataProvider dataProvider, ICommandSink commandSink, IDataSourceFactory dataSourceFactory)
    : base(id, logger, commandSink, dataSourceFactory)
    {
      AddDataSource(StateDataSourceId, dataProvider);
    }

    public OnOffData GetOnOffState()
    {
      return GetDataSource(StateDataSourceId).GetCurrentData() as OnOffData;
    }

    public void SendSwitchCommand(OnOffData data)
    {
      var command = new Command($"{Id}.{SwitchCommandId}", data);
      ProcessCommand(command);
    }
  }
}
