using HC.Core.Design;
using HC.Core.Logic;

namespace HC.Core.Factories
{
  public class DataSourceFactory : IDataSourceFactory
  {
    public IDataSource Create(string deviceId, string dataSourceId, IDataProvider dataProvider, ILog logger)
    {
      return new DataSource(GetDataSourceId(deviceId, dataSourceId), logger, dataProvider);
    }

    protected string GetDataSourceId(string deviceId, string dataSourceId)
    {
      return $"{deviceId}.{dataSourceId}";
    }
  }
}