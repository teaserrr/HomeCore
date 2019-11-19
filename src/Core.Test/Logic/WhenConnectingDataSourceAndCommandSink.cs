using FakeItEasy;
using HC.Core.DataTypes;
using HC.Core.Design;
using HC.Core.Logic;
using Xunit;

namespace HC.Core.Test.Logic
{
  public class WhenConnectingDataSourceAndCommandSink
  {
    private readonly IDataSource _dataSource;

    private readonly ICommandSink _commandSink;

    private readonly Connector _connector;

    public WhenConnectingDataSourceAndCommandSink()
    {
      _dataSource = A.Fake<IDataSource>();
      _commandSink = A.Fake<ICommandSink>();
      _connector = new Connector(_dataSource, _commandSink);
    }

    [Fact]
    public void WithNewData_CommandShouldBeProcessed()
    {
      _dataSource.DataUpdated += Raise.FreeForm.With(_dataSource, new IntegerData(42));

      A.CallTo(() => _commandSink.ProcessCommand(new IntegerData(42))).MustHaveHappened();
    }
  }
}
