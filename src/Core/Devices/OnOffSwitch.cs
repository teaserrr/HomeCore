using HC.Core.Design;
using HC.Core.DataTypes;

namespace HC.Core.Devices
{
  public class OnOffSwitch : AbstractDevice
  {
	  public const string DataSourceId = "switchDataSource";
    
    public OnOffSwitch(string id, ILog logger, IDataProvider dataProvider, IDataSourceFactory dataSourceFactory) 
        : base(id, logger, dataSourceFactory)
    {
      AddDataSource(DataSourceId, dataProvider);
    }

    public OnOffData GetOnOffState()
    {
      return GetDataSource(DataSourceId).GetCurrentData() as OnOffData;
    }
  }
}