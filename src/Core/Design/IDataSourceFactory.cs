namespace HC.Core.Design
{
  public interface IDataSourceFactory
  {
    IDataSource Create(string id, IDataProvider dataProvider, ILog logger);
  }
}