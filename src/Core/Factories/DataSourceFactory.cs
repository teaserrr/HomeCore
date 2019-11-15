using HC.Core.Design;
using HC.Core.Logic;

namespace HC.Core.Factories
{
  public class DataSourceFactory : IDataSourceFactory
  {
    public IDataSource Create(string deviceId, string dataSourceId, IDataProvider dataProvider)
    {
      return new DataSource(GetDataSourceId(deviceId, dataSourceId), dataProvider);
    }

    protected string GetDataSourceId(string deviceId, string dataSourceId)
    {
      return $"{deviceId}.{dataSourceId}";
    }
  }
}