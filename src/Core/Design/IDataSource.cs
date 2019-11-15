namespace HC.Core.Design
{
  public interface IDataSource
  {
    string Id { get; }

    IData GetCurrentData();

    IData GetPreviousData();

  }
}