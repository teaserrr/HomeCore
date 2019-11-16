using HC.Core.Design;
using HC.Core.Logic;

namespace HC.Core.Factories
{
  public class DataSourceFactory : IDataSourceFactory
  {
    public IDataSource Create(string id, IDataProvider dataProvider, ILog logger)
    {
      return new DataSource(id, logger, dataProvider);
    }
  }
}