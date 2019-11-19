using HC.Core.Design;

namespace HC.Core.Test
{
  public class TestDataUpdateEventHandler
  {
    public IData LastUpdateData { get; set; }

    public IDataSource LastUpdateDataSource { get; set; }

    public TestDataUpdateEventHandler(IDataSource dataSource)
    {
      dataSource.DataUpdated += OnDataUpdated;
    }

    private void OnDataUpdated(IDataSource dataSource, IData newData)
    {
      LastUpdateData = newData;
      LastUpdateDataSource = dataSource;
    }
  }
}
