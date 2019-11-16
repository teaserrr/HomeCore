using HC.Core.Design;
using HC.Core.DataTypes;

namespace HC.Core.Devices
{
  public class OnOffSwitch : AbstractDevice
  {
	  public const string DataId = "switchData";
    
    public OnOffSwitch(string id, ILog logger, IDataProvider dataProvider, IDataSourceFactory dataSourceFactory) 
        : base(id, logger, dataSourceFactory)
    {
      AddDataSource(DataId, dataProvider);
    }

    public OnOffData GetOnOffState()
    {
      return GetDataSource(DataId).GetCurrentData() as OnOffData;
    }
  }
}