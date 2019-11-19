using FakeItEasy;
using HC.Core.DataTypes;
using HC.Core.Design;
using HC.Core.Devices;
using HC.Core.Factories;
using Xunit;
using Xunit.Abstractions;

namespace HC.Core.Test.Devices
{
  public class WhenSendingSwitchCommand
  {
    public const string DeviceId = "testDevice";

    private ICommandConsumer _commandConsumer;

    private SwitchableLight _testDevice;

    public WhenSendingSwitchCommand(ITestOutputHelper testOutputHelper)
    {
      _commandConsumer = A.Fake<ICommandConsumer>();
      _testDevice = new SwitchableLight(DeviceId, new TestLogger(testOutputHelper), new TestDataProvider(), new DataSourceFactory(), _commandConsumer, new CommandSinkFactory());
    }

    [Fact]
    public void WithBasicCommand_ShouldBeProcessedBySink()
    {
      _testDevice.SendSwitchCommand(OnOffData.ON);

      A.CallTo(() => _commandConsumer.Consume(A<Command>._)).MustHaveHappened();
    }

    [Fact]
    public void WithBasicCommand_CommandIdShouldBeCorrect()
    {
      _testDevice.SendSwitchCommand(OnOffData.ON);

      A.CallTo(() => _commandConsumer.Consume(A<Command>.That.Matches(command => command.Id.Equals($"{DeviceId}.{SwitchableLight.SwitchCommandId}")))).MustHaveHappened();
    }

    [Fact]
    public void WithBasicCommand_CommandDataShouldBeCorrect()
    {
      _testDevice.SendSwitchCommand(OnOffData.ON);

      A.CallTo(() => _commandConsumer.Consume(A<Command>.That.Matches(command => command.Data.Equals(OnOffData.ON)))).MustHaveHappened();
    }
  }
}
