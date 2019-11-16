namespace HC.Core.Design
{
  public delegate void DataUpdatedHandler(IDataSource dataSource, IData newData);

  public interface IDataSource
  {
    string Id { get; }

    IData GetCurrentData();

    IData GetPreviousData();

    event DataUpdatedHandler DataUpdated;
  }
}