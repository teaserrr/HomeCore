using FluentAssertions;
using HC.Core.DataTypes;
using HC.Core.Devices;
using HC.Core.Factories;
using HC.Core.Test.TestEntities;
using Xunit;
using Xunit.Abstractions;

namespace HC.Core.Test.Devices
{
  public class WhenSendingSwitchCommand
  {
    public const string DeviceId = "testDevice";

    private TestCommandConsumer _testCommandConsumer;

    private SwitchableLight _testDevice;

    public WhenSendingSwitchCommand(ITestOutputHelper testOutputHelper)
    {
      _testCommandConsumer = new TestCommandConsumer();
      _testDevice = new SwitchableLight(DeviceId, new TestLogger(testOutputHelper), new TestDataProvider(), new DataSourceFactory(), _testCommandConsumer, new CommandSinkFactory());
    }

    [Fact]
    public void WithBasicCommand_ShouldBeProcessedBySink()
    {
      _testDevice.SendSwitchCommand(OnOffData.ON);

      _testCommandConsumer.LastCommand.Should().NotBeNull();
    }

    [Fact]
    public void WithBasicCommand_CommandDataShouldBeCorrect()
    {
      _testDevice.SendSwitchCommand(OnOffData.ON);

      _testCommandConsumer.LastCommand.Id.Should().EndWith(SwitchableLight.SwitchCommandId);
      _testCommandConsumer.LastCommand.Data.Should().Be(OnOffData.ON);
    }
  }
}
