using HC.Core.Design;
using HC.Core.DataTypes;

namespace HC.Core.Devices
{
  public class OnOffSwitch : AbstractDevice
  {
	  public const string DataSourceId = "switchDataSource";

	  private IDataSource _dataSource;

    public OnOffSwitch(string id, IDataProvider dataProvider, IDataSourceFactory dataSourceFactory) 
        : base(id)
    {
      _dataSource = dataSourceFactory.Create(id, DataSourceId, dataProvider);
    }

    public OnOffData GetOnOffState()
    {
      return _dataSource.GetCurrentData() as OnOffData;
    }
  }
}