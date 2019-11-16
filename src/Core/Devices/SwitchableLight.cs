using System;
using HC.Core.DataTypes;
using HC.Core.Design;

namespace HC.Core.Devices
{
  public class SwitchableLight : AbstractDevice
  {
    public const string SwitchCommandId = "switchCommand";
    public const string StateDataId = "stateData";
    
    public SwitchableLight(string id, ILog logger, IDataProvider dataProvider, IDataSourceFactory dataSourceFactory, ICommandConsumer commandConsumer, ICommandSinkFactory commandSinkFactory)
    : base(id, logger, dataSourceFactory, commandSinkFactory)
    {
      AddDataSource(StateDataId, dataProvider);
      AddCommandSink(SwitchCommandId, commandConsumer);
    }

    public OnOffData GetOnOffState()
    {
      return GetDataSource(StateDataId).GetCurrentData() as OnOffData;
    }

    public void SendSwitchCommand(OnOffData data)
    {
      ProcessCommand(SwitchCommandId, data);
    }
  }
}
