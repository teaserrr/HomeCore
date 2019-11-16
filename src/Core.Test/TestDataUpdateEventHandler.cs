using System;
using System.Collections.Generic;
using System.Text;
using HC.Core.Design;

namespace HC.Core.Test
{
  public class TestDataUpdateEventHandler
  {
    private readonly IDataSource _dataSource;

    public IData lastUpdateData { get; set; }

    public IDataSource lastUpdateDataSource { get; set; }

    public TestDataUpdateEventHandler(IDataSource dataSource)
    {
      _dataSource = dataSource;
      _dataSource.DataUpdated += OnDataUpdated;
    }

    private void OnDataUpdated(IDataSource dataSource, IData newData)
    {
      lastUpdateData = newData;
      lastUpdateDataSource = dataSource;
    }
  }
}
