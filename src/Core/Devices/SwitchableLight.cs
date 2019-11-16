using System;
using HC.Core.DataTypes;
using HC.Core.Design;

namespace HC.Core.Devices
{
  public class SwitchableLight : AbstractDevice
  {
    public const string SwitchCommandId = "switchCommand";
    public const string StateDataSourceId = "stateDataSource";
    
    public SwitchableLight(string id, ILog logger, IDataProvider dataProvider, IDataSourceFactory dataSourceFactory, ICommandConsumer commandConsumer, ICommandSinkFactory commandSinkFactory)
    : base(id, logger, dataSourceFactory, commandSinkFactory)
    {
      AddDataSource(StateDataSourceId, dataProvider);
      AddCommandSink(SwitchCommandId, commandConsumer);
    }

    public OnOffData GetOnOffState()
    {
      return GetDataSource(StateDataSourceId).GetCurrentData() as OnOffData;
    }

    public void SendSwitchCommand(OnOffData data)
    {
      ProcessCommand(SwitchCommandId, data);
    }
  }
}
