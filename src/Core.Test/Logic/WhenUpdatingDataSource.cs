using Xunit;
using HC.Core.DataTypes;
using FluentAssertions;
using Xunit.Abstractions;
using HC.Core.Logic;

namespace HC.Core.Test.Logic
{
  public class WhenUpdatingDataSource
  {
    private TestDataProvider _dataProvider;
    private DataSource _dataSource;
    private TestDataUpdateEventHandler _testDataUpdateEventHandler;

    private const string DataSourceId = "testId";

    public WhenUpdatingDataSource(ITestOutputHelper testOutputHelper)
    {
      _dataProvider = new TestDataProvider();
      _dataSource = new DataSource(DataSourceId, new TestLogger(testOutputHelper), _dataProvider);
      _testDataUpdateEventHandler = new TestDataUpdateEventHandler(_dataSource);
    }

    [Fact]
    public void WithNoUpdates_CurrentDataShouldbeNull()
    {
      var data = _dataSource.GetCurrentData();

      data.Should().BeNull();
    }

    [Fact]
    public void WithNoUpdates_PreviousDataShouldbeNull()
    {
      var data = _dataSource.GetPreviousData();

      data.Should().BeNull();
    }

    [Fact]
    public void WithSingleDataUpdate_CurrentDataShouldBeCorrect()
    {
      _dataProvider.UpdateData(DataSourceId, new IntegerData(42));
      var data = _dataSource.GetCurrentData();

      data.Should().Be(new IntegerData(42));
    }

    [Fact]
    public void WithSingleDataUpdate_PreviousDataShouldbeNull()
    {
      _dataProvider.UpdateData(DataSourceId, new IntegerData(42));
      var data = _dataSource.GetPreviousData();

      data.Should().BeNull();
    }

    [Fact]
    public void WithTwoDataUpdates_CurrentDataShouldBeCorrect()
    {
      _dataProvider.UpdateData(DataSourceId, new IntegerData(22));
      _dataProvider.UpdateData(DataSourceId, new IntegerData(42));
      var data = _dataSource.GetCurrentData();

      data.Should().Be(new IntegerData(42));
    }

    [Fact]
    public void WithTwoDataUpdates_PreviousDataShouldbeCorrect()
    {
      _dataProvider.UpdateData(DataSourceId, new IntegerData(22));
      _dataProvider.UpdateData(DataSourceId, new IntegerData(42));
      var data = _dataSource.GetPreviousData();

      data.Should().Be(new IntegerData(22));
    }

    [Fact]
    public void WithDataUpdate_EventShouldBeFired()
    {
      _dataProvider.UpdateData(DataSourceId, new IntegerData(42));

      _testDataUpdateEventHandler.lastUpdateData.Should().NotBeNull();
    }

    [Fact]
    public void WithDataUpdate_EventDataShouldBeCorrect()
    {
      _dataProvider.UpdateData(DataSourceId, new IntegerData(42));

      _testDataUpdateEventHandler.lastUpdateData.Should().Be(new IntegerData(42));
      _testDataUpdateEventHandler.lastUpdateDataSource.Should().Be(_dataSource);
    }
  }
}
